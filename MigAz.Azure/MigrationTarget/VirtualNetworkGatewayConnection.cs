﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigAz.Azure.Core;
using MigAz.Azure.Core.ArmTemplate;
using MigAz.Azure.Core.Interface;

namespace MigAz.Azure.MigrationTarget
{
    public enum VirtualNetworkGatewayConnectionType
    {
        IPSec
    }

    public class VirtualNetworkGatewayConnection : Core.MigrationTarget
    {
        private IConnection _SourceConnection;
        public int _RoutingWeight = 10;
        private String _SharedKey = String.Empty;
        private VirtualNetworkGatewayConnectionType _ConnectionType = VirtualNetworkGatewayConnectionType.IPSec;
        private LocalNetworkGateway _LocalNetworkGateway;
        private VirtualNetworkGateway _VirtualNetworkGateway;

        #region Constructors

        private VirtualNetworkGatewayConnection() : base(String.Empty, String.Empty, null) { }

        public VirtualNetworkGatewayConnection(IConnection connection, TargetSettings targetSettings, ILogProvider logProvider) : base(String.Empty, String.Empty, logProvider)
        {
            this._SourceConnection = connection;
            this.SetTargetName(this.SourceName, targetSettings);
        }

        #endregion

        public IConnection SourceConnection { get { return _SourceConnection; } }

        public String SourceName
        {
            get
            {
                if (this.SourceConnection == null)
                    return String.Empty;
                else
                    return this.SourceConnection.ToString();
            }
        }

        public String SharedKey
        {
            get { return _SharedKey; }
            set { _SharedKey = value; }
        }

        public int RoutingWeight
        {
            get { return _RoutingWeight; }
            set { _RoutingWeight = value; }
        }

        public LocalNetworkGateway LocalNetworkGateway
        {
            get { return _LocalNetworkGateway; }
            set { _LocalNetworkGateway = value; }
        }

        public VirtualNetworkGateway VirtualNetworkGateway
        {
            get { return _VirtualNetworkGateway; }
            set { _VirtualNetworkGateway = value; }
        }

        public VirtualNetworkGatewayConnectionType ConnectionType
        {
            get { return _ConnectionType; }
            set { _ConnectionType = value; }
        }

        public override string ImageKey { get { return "Connection"; } }

        public override string FriendlyObjectName { get { return "Connection"; } }


        public override void SetTargetName(string targetName, TargetSettings targetSettings)
        {
            this.TargetName = targetName.Trim().Replace(" ", String.Empty);
            this.TargetNameResult = this.TargetName;
        }
    }
}
