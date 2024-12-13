using ECommerceApp.classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Data
{
    public static class StaffRepository
    {
        private static List<Staff> staffs = new List<Staff>();

        // Adiciona um novo staff
        public static void AdicionarStaff(Staff staff)
        {
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff), "Staff não pode ser nulo.");
            }

            // Verifica se já existe um staff com o mesmo email
            if (staffs.Any(s => s.Email.Equals(staff.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Staff com o email '{staff.Email}' já existe.");
            }

            staffs.Add(staff);
            Console.WriteLine($"Staff {staff.Nome} adicionado com sucesso.");
        }

        // Obtém um staff por email
        public static Staff ObterStaffPorEmail(string email)
        {
            var staff = staffs.FirstOrDefault(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (staff == null)
            {
                throw new Exception($"Staff com email '{email}' não encontrado.");
            }
            return staff;
        }

        // Obtém todos os staffs
        public static List<Staff> ObterTodosStaffs()
        {
            return staffs;
        }

        // Remove um staff por email
        public static void RemoverStaff(string email)
        {
            var staff = staffs.FirstOrDefault(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (staff != null)
            {
                staffs.Remove(staff);
                Console.WriteLine($"Staff {staff.Nome} removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Staff não encontrado.");
            }
        }
    }
}
