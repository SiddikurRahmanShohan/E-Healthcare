﻿using E_HealthCare.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_HealthCare.DataAccessLayer
{
    class AppointmentDataAccess: DataAccess
    {
        public Appointment GetAdminAppointment()
        {
            string sql = "SELECT * fROM Appointments";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.Date = reader["Date"].ToString();
                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.PatientName = reader["PatientName"].ToString();
                appointment.Shift = reader["Shift"].ToString();
                appointment.UserId = Convert.ToInt32(reader["UserId"]);
                appointment.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                return appointment;
            }
            return null;
        }

        public List<Appointment> GetDoctorAppointments(int doctorId)
        {
            string sql = "SELECT Date,Shift,PatientName,Problem,UserId fROM Appointments WHERE doctorId=" + doctorId;
            SqlDataReader reader = this.GetData(sql);
            List<Appointment> appointments = new List<Appointment>();
            if (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.Date = reader["Date"].ToString();
                appointment.Shift = reader["Shift"].ToString();
                appointment.PatientName = reader["PatientName"].ToString();
                appointment.Problem = reader["Problem"].ToString();
                appointment.UserId = Convert.ToInt32(reader["UserId"]);
                appointments.Add(appointment);
            }
            return appointments;
        }

        public Appointment GetUserAppointment(int userId)
        {
            string sql = "SELECT Date,Shift,DoctorName,Problem fROM Appointments WHERE doctorId='" + userId;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.Date = reader["Date"].ToString();
                appointment.Shift = reader["Shift"].ToString();
                appointment.DoctorName = reader["PatientName"].ToString();
                appointment.Problem = reader["Problem"].ToString();
                return appointment;
            }
            return null;
        }

        public int AddAppointment(Appointment appointment)
        {
            string sql = "INSERT INTO Appointment(Date,DoctorName,PatientName,Problem,Shift,DoctorId,UserId) VALUES ('" + appointment.Date + "', '" + appointment.DoctorName + "','" + appointment.PatientName + "','" + appointment.Problem + "','" + appointment.Shift + "',"+ appointment.DoctorId +"," +appointment.UserId +")";
            return this.ExecuteQuery(sql);
        }

 
    }
}
