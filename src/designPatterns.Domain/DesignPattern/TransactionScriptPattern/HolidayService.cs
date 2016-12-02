using System;
using System.Collections.Generic;

namespace designPatterns.Domain.DesignPattern.TransactionScriptPattern
{
    public static class HolidayService
    {
        public static bool BookHolidayFor(int employeeId, DateTime from, DateTime to)
        {
            var booked = false;
            var numberOfDaysRequestedForHolidays = to - from;

            if (numberOfDaysRequestedForHolidays.Days <= 0) return false;
            var holidaysAvailabile = GetHolidaysRemainingFor(employeeId);

            if (holidaysAvailabile < numberOfDaysRequestedForHolidays.Days) return false;
            SubmitHolidayBookingFor(employeeId, @from, to);
            return true;
        }

        private static void SubmitHolidayBookingFor(int employeeId, object from, object to)
        {
            
        }

        private static int GetHolidaysRemainingFor(int employeeId)
        {
            var reneEmployeeDto = new EmployeeDto
            {
                Name = "Rene",
                RemainingDays = 10
            };
            return reneEmployeeDto.RemainingDays;
        }

        public static List<EmployeeDto> GetAllEmployeesOnLeaveBetween(
            DateTime From, DateTime To)
        {
            var reneEmployeeDto = new EmployeeDto
            {
                Name = "Rene",
                RemainingDays = 10
            };
            var albertoEmployeeDto = new EmployeeDto
            {
                Name = "Alberto",
                RemainingDays = 10
            };
            return new List<EmployeeDto>(){reneEmployeeDto,albertoEmployeeDto};
        }

        public static List<EmployeeDto> GetAllEmployeesWithHolidayRemaining()
        {
            var reneEmployeeDto = new EmployeeDto
            {
                Name = "Rene",
                RemainingDays = 10
            };
            return new List<EmployeeDto>() { reneEmployeeDto };
        }
    }
}