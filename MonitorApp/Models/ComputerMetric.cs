using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MonitorApp.Models
{
    public class ComputerMetric
    {
        private readonly Computer _computer;
        public IReadOnlyDictionary<string, float> CPUTemps { get; private set; }
        public IReadOnlyDictionary<string, float> CPULoad { get; private set; }
        public IReadOnlyDictionary<string, float> GPUTemps { get; private set; }
        public IReadOnlyDictionary<string, float> GPULoad { get; private set; }
        public string CPUName { get; private set; }
        public string GPUName { get; private set; }

        public ComputerMetric()
        {
            _computer = new Computer { CPUEnabled = true };
            _computer.Open();
            GetTempAndLoads();
        }

        public void GetTempAndLoads()
        {
            var coreAndTemperature = new Dictionary<string, float>();
            var coreAndLoad = new Dictionary<string, float>();

            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update();
                if (hardware.HardwareType == HardwareType.CPU)
                    CPUName = hardware.Name;
                if (hardware.HardwareType == HardwareType.GpuNvidia)
                    GPUName = hardware.Name;
                foreach (var sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                        coreAndTemperature.Add(sensor.Name, sensor.Value.Value);
                    if (sensor.SensorType == SensorType.Load && sensor.Value.HasValue)
                        coreAndLoad.Add(sensor.Name, sensor.Value.Value);
                }
            }

            CPULoad = coreAndLoad;
            CPUTemps = coreAndTemperature;
        }
    }
}