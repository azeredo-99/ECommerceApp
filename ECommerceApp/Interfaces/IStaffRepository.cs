using System.Collections.Generic;
using ECommerceApp.classes;

namespace ECommerceApp.Interfaces
{
    public interface IStaffRepository
    {
        void AdicionarStaff(Staff staff);
        Staff ObterStaffPorEmail(string email);
        List<Staff> ObterTodosStaffs();
        void AtualizarStaff(string email, Staff novoStaff);
        void RemoverStaff(string email);
    }
}
