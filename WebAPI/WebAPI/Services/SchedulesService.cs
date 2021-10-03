using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class SchedulesService
    {
        private AppDbContext _context;

        public SchedulesService(AppDbContext context)
        {
            _context = context;
        }

        public void AddMatch(ScheduleVM countryCodeVM)
        {
            var _homeClub = _context.Clubs.FirstOrDefault(c => c.Id == countryCodeVM.HomeClubId);
            if (_homeClub == null)
            {
                throw new Exception("Home club not found");
            }

            var _awayClub = _context.Clubs.FirstOrDefault(c => c.Id == countryCodeVM.AwayClubId);
            if (_awayClub == null)
            {
                throw new Exception("Away club not found");
            }

            var schedule = new Schedule()
            {
                GameNumber = countryCodeVM.GameNumber,
                Round = countryCodeVM.Round,
                Date = countryCodeVM.Date,
                Time = countryCodeVM.Time,
                Season = countryCodeVM.Season,
                HomePoints = countryCodeVM.HomePoints,
                AwayPoints = countryCodeVM.AwayPoints,
                GamePhase = countryCodeVM.GamePhase,
                Status = countryCodeVM.Status,
                Timestamp = countryCodeVM.Timestamp,
                HomeClubId = _homeClub.Id,
                AwayClubId = _awayClub.Id,
                HomeClub = _homeClub,
                AwayClub = _awayClub
            };
            
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

        public ScheduleVM GetMatchById(int id)
        {
            ScheduleVM scheduleVM = new ScheduleVM();

            var schedule = _context.Schedules.FirstOrDefault(s => s.Id == id);
            if (schedule != null)
            {
                throw new Exception("match id not found");
            }

            var _homeClub = _context.Clubs.FirstOrDefault(c => c.Id == schedule.HomeClubId);
            if (_homeClub == null)
            {
                throw new Exception("Home club not found");
            }

            var _awayClub = _context.Clubs.FirstOrDefault(c => c.Id == schedule.AwayClubId);
            if (_awayClub == null)
            {
                throw new Exception("Away club not found");
            }

            scheduleVM.GameNumber = schedule.GameNumber;
            scheduleVM.Round = schedule.Round;
            scheduleVM.Date = schedule.Date;
            scheduleVM.Time = schedule.Time;
            scheduleVM.Season = schedule.Season;
            scheduleVM.HomePoints = schedule.HomePoints;
            scheduleVM.AwayPoints = schedule.AwayPoints;
            scheduleVM.GamePhase = schedule.GamePhase;
            scheduleVM.Status = schedule.Status;
            scheduleVM.Timestamp = schedule.Timestamp;
            scheduleVM.HomeClubId = schedule.HomeClubId;
            scheduleVM.AwayClubId = schedule.AwayClubId;
            scheduleVM.HomeClubName = _homeClub.Name;
            scheduleVM.AwayClubName = _awayClub.Name;

            return scheduleVM;
        }

        public List<Schedule> GetSchedule()
        {
            return _context.Schedules.ToList();
        }

        public Schedule UpdateMatchById(int id, ScheduleVM countryCodeVM)
        {
            ScheduleVM scheduleVM = new ScheduleVM();

            var schedule = _context.Schedules.FirstOrDefault(s => s.Id == id);
            if (schedule != null)
            {
                throw new Exception("match id not found");
            }

            var _homeClub = _context.Clubs.FirstOrDefault(c => c.Id == scheduleVM.HomeClubId);
            if (_homeClub == null)
            {
                throw new Exception("Home club not found");
            }

            var _awayClub = _context.Clubs.FirstOrDefault(c => c.Id == scheduleVM.AwayClubId);
            if (_awayClub == null)
            {
                throw new Exception("Away club not found");
            }

            schedule.GameNumber = scheduleVM.GameNumber;
            schedule.Round = scheduleVM.Round;
            schedule.Date = scheduleVM.Date;
            schedule.Time = scheduleVM.Time;
            schedule.Season = scheduleVM.Season;
            schedule.HomePoints = scheduleVM.HomePoints;
            schedule.AwayPoints = scheduleVM.AwayPoints;
            schedule.GamePhase = scheduleVM.GamePhase;
            schedule.Status = scheduleVM.Status;
            schedule.Timestamp = scheduleVM.Timestamp;
            schedule.HomeClubId = scheduleVM.HomeClubId;
            schedule.AwayClubId = scheduleVM.AwayClubId;
            schedule.HomeClub = _homeClub;
            schedule.AwayClub = _awayClub;

            return schedule;
        }

        public void DeleteMatchById(int id)
        {
            var match = _context.Schedules.FirstOrDefault(cc => cc.Id == id);
            if (match != null)
            {
                _context.Schedules.Remove(match);
                _context.SaveChanges();
            }
        }
    }
}
