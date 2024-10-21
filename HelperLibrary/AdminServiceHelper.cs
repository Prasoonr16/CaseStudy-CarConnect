using DAO;
using Entity;

namespace HelperLibrary
{
    public class AdminServiceHelper
    {
        AdminService adminService = null;

        public AdminServiceHelper()
        {
            adminService = new AdminService();
        }
        public Admin getAdminById(int adminId)
        {
            return adminService.GetAdminById(adminId);
        }

        public Admin getAdminByUsername(string username)
        {
            return adminService.GetAdminByUsername(username);
        }

        public bool registerAdmin(Admin admin)
        {
            return adminService.RegisterAdmin(admin);
        }

        public bool updateAdmin(int adminId, Admin admin)
        {
            return adminService.UpdateAdmin(adminId, admin);
        }

        public bool deleteAdmin(int adminId)
        {
            return adminService.DeleteAdmin(adminId);
        }
    }
}
