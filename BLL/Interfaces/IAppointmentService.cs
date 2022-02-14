using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface  IAppointmentService
    {
        ICollection<AppointmentViewModel> GetAll();
        public ICollection<AppointmentViewModel> GetByUserId(int Id);
        public ICollection<AppointmentViewModel> GetByDoctorId(int Id);
        public void DeleteAppointment(int Id);
        public void AddAppointment(AppointmentViewModel appointmentViewModel);
        public AppointmentViewModel GetById(int Id);



    }
}
