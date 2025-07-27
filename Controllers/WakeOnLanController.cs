using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MauiWakeOnLan.Controllers;

public class WakeOnLanController
{
    internal string WakeOnLan(Models.Device device)
    {
        try
        {
            if (string.IsNullOrEmpty(device.MacAddress))
                throw new ArgumentException("MAC Address é obrigatório.");

            byte[] macBytes = ParseMacAddress(device.MacAddress);
            byte[] magicPacket = CreateMagicPacket(macBytes);

            using (var client = new UdpClient())
            {
                if (device.TypeConnection == Models.Device.ETipoConexao.WAN)
                {
                    client.Send(magicPacket, magicPacket.Length, device.HostName ?? "255.255.255.255", (int)device.Port);
                }
                else
                {
                    client.Send(magicPacket, magicPacket.Length, device.HostName ?? "255.255.255.255", 7);
                    client.Send(magicPacket, magicPacket.Length, device.HostName ?? "255.255.255.255", 9);

                }
            }
            return "Envio Realizado!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    private byte[] ParseMacAddress(string macAddress)
    {
        return macAddress.Split(':').Select(hex => Convert.ToByte(hex, 16)).ToArray();
    }

    private byte[] CreateMagicPacket(byte[] macBytes)
    {
        byte[] packet = new byte[102];
        for (int i = 0; i < 6; i++) packet[i] = 0xFF;
        for (int i = 6; i < packet.Length; i += macBytes.Length)
            Array.Copy(macBytes, 0, packet, i, macBytes.Length);
        return packet;
    }
}
