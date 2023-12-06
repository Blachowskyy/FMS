using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using Serilog;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace FMS.Services.Common
{
    public class ForkliftConnection : IForkliftConnection
    {
        public ForkliftConnection()
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
        }
        public async Task<bool> IsForkliftAvaible(string ipAddress)
        {
            try
            {
                var ping = new Ping();
                var reply = await ping.SendPingAsync(ipAddress);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                Log.Error("Forklift connection ping exception: " + ex.Message);
                return false;
            }
        }
        public async Task<bool> Connect(Forklift fork)
        {
            try
            {
                if (!await IsForkliftAvaible(fork.IpAddress))
                {
                    return false;
                }
                fork.Client ??= new TcpClient();

                var cancellationTokenSource = new CancellationTokenSource(5000);
                 await fork.Client.ConnectAsync(fork.IpAddress, fork.Port, cancellationTokenSource.Token);
                if (fork.Client.Connected)
                {
                    fork.IsConnected = true;
                }
                return true;
            }
            catch (SocketException ex)
            {
                Log.Fatal("Exception while connecting to Forklift server: " + fork.Name + ": " + ex.SocketErrorCode + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Fatal("Exception while connecting to Forklift server: " + fork.Name + ": " + ex.Message);
                return false;
            }
        }
        public async Task<bool> Reconnect(Forklift fork, int retryInterval = 5000, int maxRetries = 5)
        {
            fork.Client.Close();
            fork.Client.Dispose();
            fork.Client = new TcpClient();
            int retryCounter = 0;
            while (!fork.Client.Connected && retryCounter < maxRetries)
            {
                try
                {
                    await Connect(fork);
                    if (fork.Client.Connected)
                    {
                        await Task.Run(() =>
                        {
                            Task dataExchange = HandleDataExchange(fork);
                        });
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.Fatal("Exception while trying to reconnect to forklift: " + fork.Name + ": " + ex.Message);
                    return false;
                }
                await Task.Delay(retryInterval);
                retryCounter++;
            }
            if (retryCounter > maxRetries)
            {
                Log.Fatal("Reconnection max retries overflow!");
            }
            return false;
        }
        public Task<bool> Disconnect(Forklift fork)
        {
            try
            {
                if (fork.Client.Connected)
                {
                    fork.Client.Close();
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                Log.Fatal("Exception occured while trying to disconnect forklfit: " + fork.Name + ": " + ex.Message);
                return Task.FromResult(false);
            }
        }
        public async Task HandleDataExchange(Forklift fork)
        {
            if (fork.Client.Connected)
            {
                NetworkStream stream = fork.Client.GetStream();
                byte[] buffer = new byte[65535];
                int bytesReaded;
                try
                {
                    while ((bytesReaded = await stream.ReadAsync(buffer)) != 0)
                    {
                        #region Data exchange
                        #region Data In
                        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesReaded);
                        dataReceived = dataReceived.Replace("$", "");
                        var endPointFilter = new List<string>(dataReceived.Split('!'));
                        var forkliftData = new List<string>(endPointFilter[0].Split('&'));
                        if (forkliftData != null)
                        {
                            #region Data split and check
                            string liveDataSet = "";
                            string safetyDataSet = "";
                            string scangridDataSet = "";
                            string deltaErrorsDataSet = "";
                            string actualWorkstatesDataSet = "";
                            string ethernetStatusDataSet = "";
                            string startupDataSet = "";
                            string actualTebConfigDataSet = "";
                            string actualTaskDataSet = "";
                            string commandsConfirmationsDataSet = "";
                            if (forkliftData[0] != null)
                            {
                                liveDataSet = forkliftData[0];
                            }
                            if (forkliftData[1] != null)
                            {
                                safetyDataSet = forkliftData[1];
                            }
                            if (forkliftData[2] != null)
                            {
                                scangridDataSet = forkliftData[2];
                            }
                            if (forkliftData[3] != null)
                            {
                                deltaErrorsDataSet = forkliftData[3];
                            }
                            if (forkliftData[4] != null)
                            {
                                actualWorkstatesDataSet = forkliftData[4];
                            }
                            if (forkliftData[5] != null)
                            {
                                ethernetStatusDataSet = forkliftData[5];
                            }
                            if (forkliftData[6] != null)
                            {
                                startupDataSet = forkliftData[6];
                            }
                            if (forkliftData[7] != null)
                            {
                                actualTebConfigDataSet = forkliftData[7];
                            }
                            if (forkliftData[8] != null)
                            {
                                actualTaskDataSet = forkliftData[8];
                            }
                            if (forkliftData[9] != null)
                            {
                                commandsConfirmationsDataSet = forkliftData[9];
                            }
                            #endregion
                            #region Data to lists
                            var forkliftLiveData = new List<string>(liveDataSet.Split('#'));
                            var forkliftSafetyData = new List<string>(safetyDataSet.Split('#'));
                            var forkliftScangridsData = new List<string>(scangridDataSet.Split('#'));
                            var forkliftDeltaErrorsData = new List<string>(deltaErrorsDataSet.Split('#'));
                            var forkliftActualWorkstatesData = new List<string>(actualWorkstatesDataSet.Split('#'));
                            var forkliftEthernetData = new List<string>(ethernetStatusDataSet.Split('#'));
                            var forkliftStartupData = new List<string>(startupDataSet.Split('#'));
                            var forkliftActualTebConfigData = new List<string>(actualTebConfigDataSet.Split('#'));
                            var forkliftActualTaskData = new List<string>(actualTaskDataSet.Split('#'));
                            var forkliftCommandsConfirmationsData = new List<string>(commandsConfirmationsDataSet.Split('#'));
                            #endregion
                            #region Live data assignment
                            if (forkliftLiveData.Count > 18)
                            {
                                forkliftLiveData.RemoveAt(forkliftLiveData.Count - 1);
                            }
                            if (forkliftLiveData.Count == 18)
                            {
                                fork.Data.LastDataUpdate = Convert.ToString(DateTime.Now);
                                fork.Data.LiveParameters.PositionX = forkliftLiveData[0] + " M";
                                fork.Data.LiveParameters.PositionY = forkliftLiveData[1] + " M";
                                fork.Data.LiveParameters.PositionR = forkliftLiveData[2] + " °";
                                fork.Data.LiveParameters.BatteryVoltage = forkliftLiveData[3] + " V";
                                fork.Data.LiveParameters.BatteryPercentage = forkliftLiveData[4] + " %";
                                fork.Data.LiveParameters.BatteryCritical = Convert.ToBoolean(forkliftLiveData[5]);
                                fork.Data.LiveParameters.ActualForksHeight = forkliftLiveData[6] + " mm";
                                fork.Data.LiveParameters.ForksHeightLimiter = Convert.ToBoolean(forkliftLiveData[7]);
                                fork.Data.LiveParameters.LiveWeight = forkliftLiveData[8] + " kg";
                                fork.Data.LiveParameters.SavedCargoWeight = forkliftLiveData[9] + " kg";
                                fork.Data.LiveParameters.TiltAxis1 = forkliftLiveData[10] + " °";
                                fork.Data.LiveParameters.TiltAxis2 = forkliftLiveData[11] + " °";
                                fork.Data.LiveParameters.OverallDistanceMiliMeters = forkliftLiveData[12] + " mm";
                                fork.Data.LiveParameters.OverallDistanceMeters = forkliftLiveData[13] + " m";
                                fork.Data.LiveParameters.OverallDistanceKiloMeters = forkliftLiveData[14] + " km";
                                fork.Data.LiveParameters.ServoAngle = forkliftLiveData[15] + " °";
                                fork.Data.LiveParameters.CurrentPWM = forkliftLiveData[16] + " j";
                                fork.Data.LiveParameters.Speed = forkliftLiveData[17] + " m/s";
                            }
                            else
                            {
                                Log.Warning("Wrong forkLiveData lenght:" + forkliftLiveData.Count + ": " + forkliftLiveData);
                            }
                            #endregion
                            #region Safety data assignment
                            if (forkliftSafetyData.Count > 24)
                            {
                                forkliftSafetyData.RemoveAt(0);
                                forkliftSafetyData.RemoveAt(forkliftSafetyData.Count - 1);
                            }
                            if (forkliftSafetyData.Count == 24)
                            {
                                if (fork.Data.SafetyData != null)
                                {
                                    fork.Data.SafetyData.CpuStatus = Convert.ToBoolean(forkliftSafetyData[0]);
                                    fork.Data.SafetyData.EncoderStatus = Convert.ToBoolean(forkliftSafetyData[1]);
                                    fork.Data.SafetyData.Standstill = Convert.ToBoolean(forkliftSafetyData[2]);
                                    fork.Data.SafetyData.OverpseedGuardStatus = Convert.ToBoolean(forkliftSafetyData[3]);
                                    fork.Data.SafetyData.LeftEmergencyStopButtonStatus = Convert.ToBoolean(forkliftSafetyData[4]);
                                    fork.Data.SafetyData.RightEmergencyStopButtonStatus = Convert.ToBoolean(forkliftSafetyData[5]);
                                    fork.Data.LeftSafetyScanner.EmergencyZoneStatus = Convert.ToBoolean(forkliftSafetyData[6]);
                                    fork.Data.LeftSafetyScanner.SoftStopZoneStatus = Convert.ToBoolean(forkliftSafetyData[7]);
                                    fork.Data.LeftSafetyScanner.ReducedSpeedZoneStatus = Convert.ToBoolean(forkliftSafetyData[8]);
                                    fork.Data.LeftSafetyScanner.ContaminationWarning = Convert.ToBoolean(forkliftSafetyData[9]);
                                    fork.Data.LeftSafetyScanner.ContaminationError = Convert.ToBoolean(forkliftSafetyData[10]);
                                    fork.Data.LeftSafetyScanner.AppError = Convert.ToBoolean(forkliftSafetyData[11]);
                                    fork.Data.LeftSafetyScanner.DeviceError = Convert.ToBoolean(forkliftSafetyData[12]);
                                    fork.Data.LeftSafetyScanner.MonitoringCaseValid = Convert.ToBoolean(forkliftSafetyData[13]);
                                    fork.Data.LeftSafetyScanner.IsActive = Convert.ToBoolean(forkliftSafetyData[14]);
                                    fork.Data.RightSafetyScanner.EmergencyZoneStatus = Convert.ToBoolean(forkliftSafetyData[15]);
                                    fork.Data.RightSafetyScanner.SoftStopZoneStatus = Convert.ToBoolean(forkliftSafetyData[16]);
                                    fork.Data.RightSafetyScanner.ReducedSpeedZoneStatus = Convert.ToBoolean(forkliftSafetyData[17]);
                                    fork.Data.RightSafetyScanner.ContaminationWarning = Convert.ToBoolean(forkliftSafetyData[18]);
                                    fork.Data.RightSafetyScanner.ContaminationError = Convert.ToBoolean(forkliftSafetyData[19]);
                                    fork.Data.RightSafetyScanner.AppError = Convert.ToBoolean(forkliftSafetyData[20]);
                                    fork.Data.RightSafetyScanner.DeviceError = Convert.ToBoolean(forkliftSafetyData[21]);
                                    fork.Data.RightSafetyScanner.MonitoringCaseValid = Convert.ToBoolean(forkliftSafetyData[22]);
                                    fork.Data.RightSafetyScanner.IsActive = Convert.ToBoolean(forkliftSafetyData[23]);
                                }
                            }
                            else
                            {
                                Log.Warning("Wrong forkSafetyData lenght:" + forkliftSafetyData.Count + ": " + forkliftSafetyData);
                            }
                            #endregion
                            #region Scangrids Data assignment
                            if (forkliftScangridsData.Count > 22)
                            {
                                forkliftScangridsData.RemoveAt(0);
                                forkliftScangridsData.RemoveAt(forkliftScangridsData.Count - 1);
                            }
                            if (forkliftScangridsData.Count == 22)
                            {
                                fork.Data.LeftScangrid.IsActive = Convert.ToBoolean(forkliftScangridsData[0]);
                                fork.Data.LeftScangrid.SleepModeStatus = !Convert.ToBoolean(forkliftScangridsData[1]);
                                fork.Data.LeftScangrid.VoltageError = !Convert.ToBoolean(forkliftScangridsData[2]);
                                fork.Data.LeftScangrid.ContaminationError = !Convert.ToBoolean(forkliftScangridsData[3]);
                                fork.Data.LeftScangrid.ContaminationWarning = !Convert.ToBoolean(forkliftScangridsData[4]);
                                fork.Data.LeftScangrid.MonitoringCaseCanInputStatus = Convert.ToBoolean(forkliftScangridsData[5]);
                                fork.Data.LeftScangrid.MonitoringCaseSwitchInputStatus = Convert.ToBoolean(forkliftScangridsData[6]);
                                fork.Data.LeftScangrid.ResistanceToExternalLightError = !Convert.ToBoolean(forkliftScangridsData[7]);
                                fork.Data.LeftScangrid.ProtectiveFieldStatus = Convert.ToBoolean(forkliftScangridsData[8]);
                                fork.Data.LeftScangrid.WarningFieldStatus = Convert.ToBoolean(forkliftScangridsData[9]);
                                fork.Data.LeftScangrid.SafetyOutput = Convert.ToBoolean(forkliftScangridsData[10]);
                                fork.Data.RightScangrid.IsActive = Convert.ToBoolean(forkliftScangridsData[11]);
                                fork.Data.RightScangrid.SleepModeStatus = !Convert.ToBoolean(forkliftScangridsData[12]);
                                fork.Data.RightScangrid.VoltageError = !Convert.ToBoolean(forkliftScangridsData[13]);
                                fork.Data.RightScangrid.ContaminationError = !Convert.ToBoolean(forkliftScangridsData[14]);
                                fork.Data.RightScangrid.ContaminationWarning = !Convert.ToBoolean(forkliftScangridsData[15]);
                                fork.Data.RightScangrid.MonitoringCaseCanInputStatus = Convert.ToBoolean(forkliftScangridsData[16]);
                                fork.Data.RightScangrid.MonitoringCaseSwitchInputStatus = Convert.ToBoolean(forkliftScangridsData[17]);
                                fork.Data.RightScangrid.ResistanceToExternalLightError = !Convert.ToBoolean(forkliftScangridsData[18]);
                                fork.Data.RightScangrid.ProtectiveFieldStatus = Convert.ToBoolean(forkliftScangridsData[19]);
                                fork.Data.RightScangrid.WarningFieldStatus = Convert.ToBoolean(forkliftScangridsData[20]);
                                fork.Data.RightScangrid.SafetyOutput = Convert.ToBoolean(forkliftScangridsData[21]);
                            }
                            else
                            {
                                Log.Warning("Wrong forkScangridsData lenght:" + forkliftScangridsData.Count + ": " + forkliftScangridsData);
                            }
                            #endregion
                            #region Delta errors assignment
                            if (forkliftDeltaErrorsData.Count > 24)
                            {
                                forkliftDeltaErrorsData.RemoveAt(0);
                                forkliftDeltaErrorsData.RemoveAt(forkliftDeltaErrorsData.Count - 1);
                            }
                            if (forkliftDeltaErrorsData.Count == 24)
                            {
                                if (fork.Data.PlcErrors != null)
                                {
                                    fork.Data.PlcErrors.ErrorStatus.BatteryRead = Convert.ToBoolean(forkliftDeltaErrorsData[0]);
                                    fork.Data.PlcErrors.ErrorStatus.ForksHeightSensor = Convert.ToBoolean(forkliftDeltaErrorsData[1]);
                                    fork.Data.PlcErrors.ErrorStatus.PressureSensor = Convert.ToBoolean(forkliftDeltaErrorsData[2]);
                                    fork.Data.PlcErrors.ErrorStatus.TiltSensorAxis1 = Convert.ToBoolean(forkliftDeltaErrorsData[3]);
                                    fork.Data.PlcErrors.ErrorStatus.TiltSensorAxis2 = Convert.ToBoolean(forkliftDeltaErrorsData[4]);
                                    fork.Data.PlcErrors.ErrorStatus.ManualHandleSpeedRegulator = Convert.ToBoolean(forkliftDeltaErrorsData[5]);
                                    fork.Data.PlcErrors.ErrorStatus.CurtisSpeedWriteError = Convert.ToBoolean(forkliftDeltaErrorsData[6]);
                                    fork.Data.PlcErrors.ErrorStatus.ScangridLeftError = Convert.ToBoolean(forkliftDeltaErrorsData[7]);
                                    fork.Data.PlcErrors.ErrorStatus.ScangridRightError = Convert.ToBoolean(forkliftDeltaErrorsData[8]);
                                    fork.Data.PlcErrors.ErrorStatus.ServoHaltError = Convert.ToBoolean(forkliftDeltaErrorsData[9]);
                                    fork.Data.PlcErrors.ErrorStatus.ServoMoveError = Convert.ToBoolean(forkliftDeltaErrorsData[10]);
                                    fork.Data.PlcErrors.ErrorStatus.ServoPositionReadError = Convert.ToBoolean(forkliftDeltaErrorsData[11]);
                                    fork.Data.PlcErrors.ErrorCodes.BatteryReadErrorCode = forkliftDeltaErrorsData[12];
                                    fork.Data.PlcErrors.ErrorCodes.ForksHeightErrorCode = forkliftDeltaErrorsData[13];
                                    fork.Data.PlcErrors.ErrorCodes.PressureSensorErrorCode = forkliftDeltaErrorsData[14];
                                    fork.Data.PlcErrors.ErrorCodes.TiltSensorAxis1ErrorCode = forkliftDeltaErrorsData[15];
                                    fork.Data.PlcErrors.ErrorCodes.TiltSensorAxis2ErrorCode = forkliftDeltaErrorsData[16];
                                    fork.Data.PlcErrors.ErrorCodes.ManualHandleSpeedRegulatorErrorCode = forkliftDeltaErrorsData[17];
                                    fork.Data.PlcErrors.ErrorCodes.CurtisSpeedWriteErrorCode = forkliftDeltaErrorsData[18];
                                    fork.Data.PlcErrors.ErrorCodes.ScangridLeftErrorCode = forkliftDeltaErrorsData[19];
                                    fork.Data.PlcErrors.ErrorCodes.ScangridRightErrorCode = forkliftDeltaErrorsData[20];
                                    fork.Data.PlcErrors.ErrorCodes.ServoHaltErrorCode = forkliftDeltaErrorsData[21];
                                    fork.Data.PlcErrors.ErrorCodes.ServoMoveErrorCode = forkliftDeltaErrorsData[22];
                                    fork.Data.PlcErrors.ErrorCodes.ServoPositionReadErrorCode = forkliftDeltaErrorsData[23];
                                }
                            }
                            else
                            {
                                Log.Warning("Wrong deltaErrorDatsa lenght:" + forkliftDeltaErrorsData.Count + ": " + forkliftDeltaErrorsData);
                            }
                            #endregion
                            #region Workstates assignment
                            if (forkliftActualWorkstatesData.Count > 14)
                            {
                                forkliftActualWorkstatesData.RemoveAt(0);
                                forkliftActualWorkstatesData.RemoveAt(forkliftActualWorkstatesData.Count - 1);
                            }
                            if (forkliftActualWorkstatesData.Count == 14)
                            {
                                fork.Data.ActualWorkstates.S01 = Convert.ToBoolean(forkliftActualWorkstatesData[0]);
                                fork.Data.ActualWorkstates.S02 = Convert.ToBoolean(forkliftActualWorkstatesData[1]);
                                fork.Data.ActualWorkstates.S03 = Convert.ToBoolean(forkliftActualWorkstatesData[2]);
                                fork.Data.ActualWorkstates.S1 = Convert.ToBoolean(forkliftActualWorkstatesData[3]);
                                fork.Data.ActualWorkstates.S2 = Convert.ToBoolean(forkliftActualWorkstatesData[4]);
                                fork.Data.ActualWorkstates.S3 = Convert.ToBoolean(forkliftActualWorkstatesData[5]);
                                fork.Data.ActualWorkstates.S4 = Convert.ToBoolean(forkliftActualWorkstatesData[6]);
                                fork.Data.ActualWorkstates.S40 = Convert.ToBoolean(forkliftActualWorkstatesData[7]);
                                fork.Data.ActualWorkstates.S41 = Convert.ToBoolean(forkliftActualWorkstatesData[8]);
                                fork.Data.ActualWorkstates.S42 = Convert.ToBoolean(forkliftActualWorkstatesData[9]);
                                fork.Data.ActualWorkstates.S43 = Convert.ToBoolean(forkliftActualWorkstatesData[10]);
                                fork.Data.ActualWorkstates.S44 = Convert.ToBoolean(forkliftActualWorkstatesData[11]);
                                fork.Data.ActualWorkstates.S45 = Convert.ToBoolean(forkliftActualWorkstatesData[12]);
                                fork.Data.ActualWorkstates.S46 = Convert.ToBoolean(forkliftActualWorkstatesData[13]);
                            }
                            else
                            {
                                Log.Warning("Wrong ActualWorkstatesData lenght:" + forkliftActualWorkstatesData.Count + ": " + forkliftActualWorkstatesData);
                            }
                            #endregion
                            #region Ethernet status assignment
                            if (forkliftEthernetData.Count > 10)
                            {
                                forkliftEthernetData.RemoveAt(0);
                                forkliftEthernetData.RemoveAt(forkliftEthernetData.Count - 1);
                            }
                            if (forkliftEthernetData.Count == 10)
                            {
                                fork.Data.Startup.GatewayStart = Convert.ToBoolean(forkliftEthernetData[0]);
                                fork.Data.Startup.LidarLoc = Convert.ToBoolean(forkliftEthernetData[1]);
                                fork.Data.Startup.Plc = Convert.ToBoolean(forkliftEthernetData[2]);
                                fork.Data.Startup.SafetyScannerLeft = Convert.ToBoolean(forkliftEthernetData[3]);
                                fork.Data.Startup.SafetyScannerRight = Convert.ToBoolean(forkliftEthernetData[4]);
                                fork.Data.Startup.FlexiGatewayEthernet = Convert.ToBoolean(forkliftEthernetData[5]);
                                fork.Data.Startup.FlexiGatewayModbus = Convert.ToBoolean(forkliftEthernetData[6]);
                                fork.Data.Startup.GatewayEnd = Convert.ToBoolean(forkliftEthernetData[7]);
                                fork.Data.Startup.Fms = Convert.ToBoolean(forkliftEthernetData[8]);
                                fork.Data.Startup.OverallResult = Convert.ToBoolean(forkliftEthernetData[9]);

                            }
                            else
                            {
                                Log.Warning("Wrong EthernetStatusData lenght:" + forkliftEthernetData.Count + ": " + forkliftEthernetData);
                            }
                            #endregion
                            #region Startup status data
                            if (forkliftStartupData.Count > 5)
                            {
                                forkliftStartupData.RemoveAt(0);
                                forkliftStartupData.RemoveAt(forkliftStartupData.Count - 1);
                            }
                            if (forkliftStartupData.Count == 5)
                            {
                                fork.Data.Startup.EthernetTest = Convert.ToBoolean(forkliftStartupData[0]);
                                fork.Data.Startup.ScangridsTest = Convert.ToBoolean(forkliftStartupData[1]);
                                fork.Data.Startup.ServoTest = Convert.ToBoolean(forkliftStartupData[2]);
                                fork.Data.Startup.CurtisTest = Convert.ToBoolean(forkliftStartupData[3]);
                                fork.Data.Startup.ForksTest = Convert.ToBoolean(forkliftStartupData[4]);
                            }
                            else
                            {
                                Log.Warning("Wrong StartupStatusData lenght:" + forkliftStartupData.Count + ": " + forkliftStartupData);
                            }
                            #endregion
                            #region Actual TEB configuration assingment
                            if (forkliftActualTebConfigData.Count > 19)
                            {
                                forkliftActualTebConfigData.RemoveAt(0);
                                forkliftActualTebConfigData.RemoveAt(forkliftActualTebConfigData.Count - 1);
                            }
                            if (forkliftActualTebConfigData.Count == 19)
                            {
                                fork.Data.ActualTebConfig.WheelBase = forkliftActualTebConfigData[0];
                                fork.Data.ActualTebConfig.TurningRadius = forkliftActualTebConfigData[1];
                                fork.Data.ActualTebConfig.ForwardMaxVelocity = forkliftActualTebConfigData[2];
                                fork.Data.ActualTebConfig.BackwardMaxVelocity = forkliftActualTebConfigData[3];
                                fork.Data.ActualTebConfig.TurningMaxVelocity = forkliftActualTebConfigData[4];
                                fork.Data.ActualTebConfig.AccelerationLimitX = forkliftActualTebConfigData[5];
                                fork.Data.ActualTebConfig.TurningAccelerationLimit = forkliftActualTebConfigData[6];
                                fork.Data.ActualTebConfig.GoalToleranceXY = forkliftActualTebConfigData[7];
                                fork.Data.ActualTebConfig.GoalToleranceYaw = forkliftActualTebConfigData[8];
                                fork.Data.ActualTebConfig.AllowInitializeWithBackwardMotion = Convert.ToBoolean(forkliftActualTebConfigData[9]);
                                fork.Data.ActualTebConfig.MinimalObstacleDistance = forkliftActualTebConfigData[10];
                                fork.Data.ActualTebConfig.StaticObstacleInflationRadius = forkliftActualTebConfigData[11];
                                fork.Data.ActualTebConfig.DynamicObstacleInflationRadius = forkliftActualTebConfigData[12];
                                fork.Data.ActualTebConfig.IncludeCostmapObstacles = Convert.ToBoolean(forkliftActualTebConfigData[13]);
                                fork.Data.ActualTebConfig.IncludeDynamicObstacles = Convert.ToBoolean(forkliftActualTebConfigData[14]);
                                fork.Data.ActualTebConfig.OscillationRecovery = Convert.ToBoolean(forkliftActualTebConfigData[15]);
                                fork.Data.ActualTebConfig.DtRef = forkliftActualTebConfigData[16];
                                fork.Data.ActualTebConfig.DtHysteresis = forkliftActualTebConfigData[17];
                                fork.Data.ActualTebConfig.SaveSettings = Convert.ToBoolean(forkliftActualTebConfigData[18]);
                            }
                            else
                            {
                                Log.Warning("Wrong Actual TEB config data lenght:" + forkliftActualTebConfigData.Count + ": " + forkliftActualTebConfigData);
                            }
                            #endregion
                            #region Actual task assingment
                            if (forkliftActualTebConfigData.Count > 5)
                            {
                                forkliftActualTaskData.RemoveAt(0);
                                forkliftActualTaskData.RemoveAt(forkliftActualTaskData.Count - 1);
                            }
                            if (forkliftActualTaskData.Count == 5)
                            {
                                fork.Data.ActualTask.Id = Convert.ToInt32(forkliftActualTaskData[0]);
                                fork.Data.ActualTask.JobType.Id = Convert.ToInt32(forkliftActualTaskData[1]);
                                fork.Data.ActualTask.JobStepLocation.PositionX = forkliftActualTaskData[2];
                                fork.Data.ActualTask.JobStepLocation.PositionY = forkliftActualTaskData[2];
                                fork.Data.ActualTask.JobStepLocation.PositionR = forkliftActualTaskData[2];
                            }
                            else
                            {
                                Log.Warning("Wrong Actual task data lenght:" + forkliftActualTaskData.Count + ": " + forkliftActualTaskData);
                            }
                            #endregion
                            #region Orders confirmations assignment
                            if (forkliftCommandsConfirmationsData.Count > 9)
                            {
                                forkliftCommandsConfirmationsData.RemoveAt(0);
                                forkliftCommandsConfirmationsData.RemoveAt(forkliftCommandsConfirmationsData.Count - 1);
                            }
                            if (forkliftCommandsConfirmationsData.Count == 9)
                            {
                                fork.Data.OrdersConfirmations.StartAutoMode = Convert.ToBoolean(forkliftCommandsConfirmationsData[0]);
                                fork.Data.OrdersConfirmations.StartManualMode = Convert.ToBoolean(forkliftCommandsConfirmationsData[1]);
                                fork.Data.OrdersConfirmations.StartWork = Convert.ToBoolean(forkliftCommandsConfirmationsData[2]);
                                fork.Data.OrdersConfirmations.Pause = Convert.ToBoolean(forkliftCommandsConfirmationsData[3]);
                                fork.Data.OrdersConfirmations.EmergencyStop = Convert.ToBoolean(forkliftCommandsConfirmationsData[4]);
                                fork.Data.OrdersConfirmations.Continue = Convert.ToBoolean(forkliftCommandsConfirmationsData[5]);
                                fork.Data.OrdersConfirmations.Stop = Convert.ToBoolean(forkliftCommandsConfirmationsData[6]);
                                fork.Data.OrdersConfirmations.StartTask = Convert.ToBoolean(forkliftCommandsConfirmationsData[7]);
                                fork.Data.OrdersConfirmations.CancelTask = Convert.ToBoolean(forkliftCommandsConfirmationsData[8]);
                            }
                            else
                            {
                                Log.Warning("Wrong Orders confirmations data lenght:" + forkliftCommandsConfirmationsData.Count + ": " + forkliftCommandsConfirmationsData);
                            }
                            #endregion
                        }
                        #endregion
                        #region Data out
                        #region Prepare local variables
                        string messageToSend = string.Empty;
                        string orders = string.Empty;
                        string task = string.Empty;
                        string tebConfiguration = string.Empty;
                        List<object> ordersList = [];
                        List<object> taskList = [];
                        List<object> tebConfigList = [];
                        #endregion
                        #region Assign data to orders list
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.StartAutoMode));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.StartManualMode));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.Pause));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.Stop));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.EmergencyStop));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.Continue));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.StartWork));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.StartTask));
                        ordersList.Add(Convert.ToString(fork.Data.OrdersSend.CancelTask));
                        #endregion
                        #region Assign data to task list
                        taskList.Add(Convert.ToString(fork.Data.TaskSend.Id));
                        taskList.Add(Convert.ToString(fork.Data.TaskSend.JobType.Id));
                        taskList.Add(fork.Data.TaskSend.JobStepLocation.PositionX);
                        taskList.Add(fork.Data.TaskSend.JobStepLocation.PositionY);
                        taskList.Add(fork.Data.TaskSend.JobStepLocation.PositionR);
                        #endregion
                        #region Assign data to teb config list
                        tebConfigList.Add(fork.Data.TebConfig.ForwardMaxVelocity);
                        tebConfigList.Add(fork.Data.TebConfig.BackwardMaxVelocity);
                        tebConfigList.Add(fork.Data.TebConfig.TurningMaxVelocity);
                        tebConfigList.Add(fork.Data.TebConfig.AccelerationLimitX);
                        tebConfigList.Add(fork.Data.TebConfig.TurningAccelerationLimit);
                        tebConfigList.Add(fork.Data.TebConfig.WheelBase);
                        tebConfigList.Add(fork.Data.TebConfig.TurningRadius);
                        tebConfigList.Add(fork.Data.TebConfig.GoalToleranceXY);
                        tebConfigList.Add(fork.Data.TebConfig.GoalToleranceYaw);
                        tebConfigList.Add(fork.Data.TebConfig.MinimalObstacleDistance);
                        tebConfigList.Add(fork.Data.TebConfig.StaticObstacleInflationRadius);
                        tebConfigList.Add(fork.Data.TebConfig.DynamicObstacleInflationRadius);
                        tebConfigList.Add(fork.Data.TebConfig.DtRef);
                        tebConfigList.Add(fork.Data.TebConfig.DtHysteresis);
                        tebConfigList.Add(Convert.ToString(fork.Data.TebConfig.IncludeCostmapObstacles));
                        tebConfigList.Add(Convert.ToString(fork.Data.TebConfig.IncludeDynamicObstacles));
                        tebConfigList.Add(Convert.ToString(fork.Data.TebConfig.OscillationRecovery));
                        tebConfigList.Add(Convert.ToString(fork.Data.TebConfig.AllowInitializeWithBackwardMotion));
                        tebConfigList.Add(Convert.ToString(fork.Data.TebConfig.SaveSettings));
                        #endregion
                        #region Create strings to send from lists
                        int counter = 0;
                        foreach (string data in ordersList.Cast<string>())
                        {
                            if (counter == 0)
                            {
                                orders = data + "#";
                            }
                            else
                            {
                                orders = orders + data + "#";
                            }
                            counter++;
                        }
                        counter = 0;
                        foreach (string data in taskList.Cast<string>())
                        {
                            if (counter == 0)
                            {
                                task = data + "#";
                            }
                            else
                            {
                                task = task + data + "#";
                            }
                            counter++;
                        }
                        counter = 0;
                        foreach (string data in tebConfigList.Cast<string>())
                        {
                            if (counter == 0)
                            {
                                tebConfiguration = data + "#";
                            }
                            else
                            {
                                tebConfiguration = tebConfiguration + data + "#";
                            }
                            counter++;
                        }
                        #endregion
                        #region Data send
                        messageToSend = orders + "&" + task + "&" + tebConfiguration;
                        byte[] message = Encoding.UTF8.GetBytes(messageToSend);
                        stream.Write(message, 0, message.Length);
                        #endregion
                        #endregion
                        #endregion
                    }
                    await Reconnect(fork);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    await Reconnect(fork);
                }
            }
            else
            {
                await Reconnect(fork);
            }
        }
    }
}
