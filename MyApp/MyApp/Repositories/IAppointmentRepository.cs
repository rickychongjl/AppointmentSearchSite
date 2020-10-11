using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Entities;

namespace MyApp.Repositories
{
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Returns active appointments.
        /// </summary>
        IQueryable<Appointment> GetAppointments(bool includeDeleted = false);
    }
}
