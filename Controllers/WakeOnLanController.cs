using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MauiWakeOnLan.Controllers;

public static class WakeOnLanController
{
    internal static string WakeOnLan(Models.Device device)
    {
        try
        {
            if (string.IsNullOrEmpty(device.MacAddress))
                throw new ArgumentException("MAC Address é obrigatório.");

            byte[] macBytes = ParseMacAddress(device.MacAddress);
            byte[] magicPacket = CreateMagicPacket(macBytes);

            using (var client = new UdpClient())
            {
                if (string.IsNullOrEmpty(device.HostName))
                    throw new ArgumentException("HostName é obrigatório para conexão WAN.");

                switch (device.TypeConnection)
                {
                    case Models.Device.ETipoConexao.WAN:
                        client.Send(magicPacket, magicPacket.Length, device.HostName, (int)device.Port);
                        break;

                    case Models.Device.ETipoConexao.LAN:
                        client.Send(magicPacket, magicPacket.Length, device.HostName, 7);
                        client.Send(magicPacket, magicPacket.Length, device.HostName, 9);
                        break;
                }
            }
            return string.Empty;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private static byte[] ParseMacAddress(string macAddress)
    {
        return macAddress.Split(':').Select(hex => Convert.ToByte(hex, 16)).ToArray();
    }

    private static byte[] CreateMagicPacket(byte[] macBytes)
    {
        byte[] packet = new byte[102];
        for (int i = 0; i < 6; i++) packet[i] = 0xFF;
        for (int i = 6; i < packet.Length; i += macBytes.Length)
            Array.Copy(macBytes, 0, packet, i, macBytes.Length);
        return packet;
    }
}
