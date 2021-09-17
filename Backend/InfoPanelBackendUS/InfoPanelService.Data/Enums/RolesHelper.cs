using DMExceptions;
using DMUtils.Actions;
using InfoPanelService.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace InfoPanelService.Data.Enums
{
    public class RolesHelper
    {
        private readonly InfoPanelContext db = new InfoPanelContext();
        private ImmutableList<DataObjects.Role> CachedRoles;

        private const String cTruckDriver = "Truck driver";
        private const String cGasStationChainsCashier = "Gas Station Cashier";
        private const String cRouteManager = "Route manager";
        private const String cSEDriver = "SE Driver";
        private const String cCustomer = "Customer";

        private Dictionary<string, string> cacheOfRoles = new Dictionary<string, string>();


        public RolesHelper()
        {
            ReloadRoles();
        }

        public void ReloadRoles()
        {
            using (var action = new InfoAction(nameof(ReloadRoles)))
            {
                try
                {
                    CachedRoles = ImmutableList.ToImmutableList<DataObjects.Role>(db.Roles);
                    action.Success("CachedRoles="+String.Join(Environment.NewLine, CachedRoles.Select(c=>c.ToString())));
                }
                catch (Exception ex)
                {
                    CachedRoles = ImmutableList<DataObjects.Role>.Empty;
                    action.Failure(ex);
                }
            }
        }

        public String GetRoleIdOfTruckDriver()
        {
            return GetRoleByName(cTruckDriver);
        }

        public String GetRoleIdOfRouteManager()
        {
            return GetRoleByName(cRouteManager);
        }

        public String GetRoleIdOfGasStationChainsCashier()
        {
            return GetRoleByName(cGasStationChainsCashier);
        }        

        private string GetRoleByName(string roleName)
        {
            using (var action = new InfoAction(nameof(GetRoleByName)))
            {
                try
                {
                    if (string.IsNullOrEmpty(roleName))
                        throw new ArgumentNullException(roleName);

                    if (cacheOfRoles.ContainsKey(roleName))
                    {
                        return cacheOfRoles[roleName];
                    }

                    action.DumpParameters(nameof(roleName), roleName);

                    var foundRole = CachedRoles.FirstOrDefault(c => String.Compare(c.Name, roleName, true) == 0);
                    if (foundRole == null)
                    {
                        foundRole = db.Roles.FirstOrDefault(c => String.Compare(c.Name, roleName, true) == 0);
                    }

                    if (foundRole == null)
                        throw new DMException($"Unable to find the role by name={roleName}");

                    action.Success("foundRole=" + foundRole);
                    cacheOfRoles[roleName] = foundRole.Id;
                    return foundRole.Id;
                }
                catch (Exception ex)
                {
                    action.Failure(ex);
                    throw;
                }
            }
        }

        public string GetRoleIdOfSEDriver()
        {
            return GetRoleByName(cSEDriver);
        }

        public string GetRoleIdOfCustomer()
        {
            return GetRoleByName(cCustomer);
        }
    }
}
