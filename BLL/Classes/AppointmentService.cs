using AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Classes
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IMapper mapper;
        private readonly PetClinicDBContext context;

        public AppointmentService(
            IMapper mapper,
            PetClinicDBContext context
            )
        {
            this.mapper = mapper;
            this.context = context;
        }

        public ICollection<AppointmentViewModel> GetAll()
        {
            var appointment = context.Appointments.ToList();
            return (ICollection<AppointmentViewModel>)mapper.Map<AppointmentViewModel>(appointment);
        }

        public AppointmentViewModel GetById(int Id)
        {
            var appointment= context.Appointments.FirstOrDefault(x => x.Id == Id);
            return mapper.Map<AppointmentViewModel>(appointment);
        }

        public void AddAppointment(AppointmentViewModel appointmentViewModel)
        {
           var appointment = mapper.Map<Appointment>(appointmentViewModel);
           context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        public void DeleteAppointment(int Id)
        {
            var appointment = context.Appointments.FirstOrDefault(y => y.Id == Id);
            context.Appointments.Remove(appointment);
            context.SaveChanges();
        }

        public ICollection<AppointmentViewModel> GetByDoctorId(int Id)
        {
            var appointments = context.Appointments.FirstOrDefault(x => x.DoctorId == Id);

            return mapper.Map<ICollection<AppointmentViewModel>>(appointments);
        }

        public ICollection<AppointmentViewModel> GetByUserId(int Id)
        {
            var appointments = context.Appointments.FirstOrDefault(x => x.Pet.OwnerId == Id);
            return mapper.Map<ICollection<AppointmentViewModel>>(appointments);
        }
    }
}
