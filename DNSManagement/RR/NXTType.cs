﻿///*
//DNSManagement - Wrapper for WMI Management of MS DNS
//Copyright (C) 2011 Dror Gluska
	
//This library is free software; you can redistribute it and/or
//modify it under the terms of the GNU Lesser General Public License
//(LGPL) as published by the Free Software Foundation; either
//version 2.1 of the License, or (at your option) any later version.
//The terms of redistributing and/or modifying this software also
//include exceptions to the LGPL that facilitate static linking.
 	
//This library is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//Lesser General Public License for more details.
 	
//You should have received a copy of the GNU Lesser General Public License
//along with this library; if not, write to Free Software Foundation, Inc.,
//51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA


//Change log:
//2011-05-17 - Initial version
//2012-03-09 - Fixed all saving methods to return connected records
 
//*/


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DNSManagement.Extensions;
//using System.Management;

//namespace DNSManagement.RR
//{
//    /// <summary>
//    /// Represents a Next (NXT) RR. 
//    /// </summary>
//    public class NXTType : ResourceRecord
//    {
//        private ManagementObject m_mo;

//        internal NXTType(ManagementObject mo)
//            : base(mo)
//        {
//            m_mo = mo;
//        }

//        /// <summary>
//        /// Next domain name.
//        /// </summary>
//        public string NextDomainName
//        {
//            get
//            {
//                return Convert.ToString(m_mo["NextDomainName"]);
//            }
//        }

//        /// <summary>
//        /// Space-separated list of the RR-type mnemonics for the owner name of the NXT Resource Record.
//        /// </summary>
//        public string Types
//        {
//            get
//            {
//                return Convert.ToString(m_mo["Types"]);
//            }
//        }

        
//        /// <summary>
//        /// Instantiates an NXT Resource Record based on the data in the method's input parameters: the record's DNS Server Name, Container Name, Owner Name, class (default = IN), time-to-live value, and WINS mapping flag, reverse look-up time out, WINS cache time out, and domain name to append. It returns a reference to the new object as an output parameter. 
//        /// </summary>
//        /// <param name="server">Server object</param>
//        /// <param name="dnsServerName">Fully Qualified Domain Name (FQDN) or IP address of the DNS Server that contains this RR.</param>
//        /// <param name="containerName">Name of the Container for the Zone, Cache, or RootHints instance which contains this RR.</param>
//        /// <param name="ownerName">Owner FQDN for the RR.</param>
//        /// <param name="recordClass">Class of the RR.</param>
//        /// <param name="ttl">Time, in seconds, that the RR can be cached by a DNS resolver.</param>
//        /// <param name="nextDomainName">Next domain name.</param>
//        /// <param name="types">Space-separated list of the RR-type mnemonics for the owner name of the NXT Resource Record.</param>
//        /// <returns>the new object.</returns>
//        public static NXTType CreateInstanceFromPropertyData(
//            Server server,
//            string dnsServerName,
//            string containerName,
//            string ownerName,
//            RecordClassEnum? recordClass,
//            TimeSpan? ttl,
//            string nextDomainName, string types)
//        {
//            if (server == null)
//                throw new ArgumentNullException("server is required");

//            ManagementClass dnsClass = new ManagementClass(server.m_scope, new ManagementPath("MicrosoftDNS_NXTType"), null);
//            ManagementBaseObject inParams = dnsClass.GetMethodParameters("CreateInstanceFromPropertyData");
//            inParams["DnsServerName"] = dnsServerName;
//            inParams["ContainerName"] = containerName;
//            inParams["OwnerName"] = ownerName;
//            if (recordClass != null)
//                inParams["RecordClass"] = (UInt32)recordClass.Value;
//            if (ttl != null)
//                inParams["TTL"] = ttl.Value.TotalSeconds;
//            inParams["NextDomainName"] = nextDomainName;
//            inParams["Types"] = types;

//            try
//            {
//                return new NXTType(new ManagementObject(server.m_scope, new ManagementPath(dnsClass.InvokeMethod("CreateInstanceFromPropertyData", inParams, null)["RR"].ToString()), null));
//            }
//            catch (ManagementException me)
//            {
//                throw new WMIException(me);
//            }
//        }

       
//        /// <summary>
//        /// Updates the TTL, Mapping Flag, Look-up Time out, Cache Time out and Result Domain to the values specified as the input parameters of this method. If a new value for a parameter is not specified, then the current value for the parameter is not changed. The method returns a reference to the modified object as an output parameter. 
//        /// </summary>
//        /// <param name="ttl">Optional - Time, in seconds, that the RR can be cached by a DNS resolver.</param>
//        /// <param name="nextDomainName">Next domain name.</param>
//        /// <param name="types">Space-separated list of the RR-type mnemonics for the owner name of the NXT Resource Record.</param>
//        /// <returns>the modified object.</returns>
//        public NXTType Modify(TimeSpan? ttl, string nextDomainName, string types)
//        {
//            ManagementBaseObject inParams = m_mo.GetMethodParameters("Modify");
//            if ((ttl != null) && (ttl != this.TTL))
//                inParams["TTL"] = ttl.Value.TotalSeconds;

//            if ((!string.IsNullOrEmpty(nextDomainName)) && (nextDomainName != this.NextDomainName))
//                inParams["NextDomainName"] = nextDomainName;

//            if ((!string.IsNullOrEmpty(types)) && (types != this.Types))
//                inParams["Types"] = types;

//            //return new NXTType((ManagementObject)m_mo.InvokeMethod("Modify", inParams, null));
//            return new NXTType(new ManagementObject(m_mo.Scope, new ManagementPath(m_mo.InvokeMethod("Modify", inParams, null)["RR"].ToString()), null));
//        }

//        public override string ToString()
//        {
//            StringBuilder sb = new StringBuilder();

//            sb.AppendLineFormat("NextDomainName={0}", NextDomainName);
//            sb.AppendLineFormat("Types={0}", Types);

//            //RR
//            base.ToString(sb);

//            return sb.ToString();
//        }
//    }
//}
