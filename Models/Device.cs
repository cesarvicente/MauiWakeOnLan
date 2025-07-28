using MauiWakeOnLan.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWakeOnLan.Models;

public class Device
{
    public string Name { get; set; } = string.Empty;

    public string? MacAddress { get; set; }

    public string? HostName { get; set; }

    public uint Port { get; set; }

    public ETipoConexao TypeConnection { get; set; }

    public enum ETipoConexao
    {
        LAN,
        WAN,
    }

    public string Wake()
    {
        return WakeOnLanController.WakeOnLan(this);
    }
}
