using EasyModbus;
using System;
using System.Text;

public class ModbusServerManager
{
    private ModbusServer modbusServer;

    public ModbusServerManager(int port = 502)
    {
        InitializeModbusServer(port);
    }

    private void InitializeModbusServer(int port)
    {
        modbusServer = new ModbusServer();
        modbusServer.Port = port;
        modbusServer.UnitIdentifier = 0; // Slave ID
        modbusServer.Listen();
    }

    public void UpdateModbusRegisters(string dateNow, string device_ID, double maxMovingAverage, double intervalToMax,
                                        double cycleTimeSeconds, double totalArea, string LBWheelStatusText, string warningMessages)
    {
        if (dateNow == null || device_ID == null || LBWheelStatusText == null || warningMessages == null)
        {
            // Handle null values appropriately.
            return; // Returning 0 to indicate that the function did not proceed due to null values.
        }

        int offset = 0; // Keeps track of where to write in holding registers

        // Convert dateNow to ASCII and store in holding registers
        byte[] dateNowBytes = Encoding.ASCII.GetBytes(dateNow);
        for (int i = 0; i < dateNowBytes.Length; i++)
        {
            modbusServer.holdingRegisters[i] = dateNowBytes[i];
        }

        // Convert device_ID to ASCII and store
        byte[] device_IDBytes = Encoding.ASCII.GetBytes(device_ID);
        for (int i = 0; i < device_IDBytes.Length; i++)
        {
            modbusServer.holdingRegisters[dateNowBytes.Length + i] = device_IDBytes[i];
        }

        // Function to store double into holdingRegisters
        Action<double> storeDouble = (double value) =>
        {
            value = Math.Round(value, 2);
            byte[] bytes = BitConverter.GetBytes(value);
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                ushort ushortValue = BitConverter.ToUInt16(bytes, i * 2);
                modbusServer.holdingRegisters[offset++] = (short)ushortValue;  // Explicit cast
            }
        };


        // Set the offset appropriately before storing the double values
        offset = dateNowBytes.Length + device_IDBytes.Length;  // ASCII strings' lengths

        // Store double values
        storeDouble(maxMovingAverage);
        storeDouble(intervalToMax);
        storeDouble(cycleTimeSeconds);
        storeDouble(totalArea);


        // Convert LBWheelStatus.Text and warningMessages to ASCII and store
        byte[] lbWheelStatusBytes = Encoding.ASCII.GetBytes(LBWheelStatusText);
        byte[] warningMessagesBytes = Encoding.ASCII.GetBytes(warningMessages);

        for (int i = 0; i < lbWheelStatusBytes.Length; i++)
        {
            modbusServer.holdingRegisters[offset++] = lbWheelStatusBytes[i];
        }

        for (int i = 0; i < warningMessagesBytes.Length; i++)
        {
            modbusServer.holdingRegisters[offset++] = warningMessagesBytes[i];
        }
    }

    public void Stop()
    {
        modbusServer.StopListening();
    }
}
