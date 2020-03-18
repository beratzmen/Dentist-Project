using Dentist.Business.Concrete;
using Dentist.DataAccess.Concrete.EntityFramework.Repository;
using Dentist.Entities.Help;
using Dentist.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dentist.RestApi.Controllers
{
    public class AppointmentController : ApiController
    {
        AppointmentManager _appointmentService = new AppointmentManager(new EfAppointmentRepository());

        [HttpGet]
        public List<Appointment> GetAll()
        {
            return _appointmentService.GetAll();
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            return _appointmentService.Delete(id);
        }
        [HttpPost]
        public ApiResponse Add(Appointment entity)
        {
            ApiResponse response = new ApiResponse();
            response.Status = _appointmentService.Add(entity);
            response.Data = entity;
            return response;
        }
        [HttpGet]
        public bool StatusUpdate(int id, short status)
        {
            return _appointmentService.StatusUpdate(id, status);
        }
    }
}
