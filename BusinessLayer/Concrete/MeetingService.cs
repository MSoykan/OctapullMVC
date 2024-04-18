using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class MeetingService : IMeetingService {
        public Task AddMeeting(Meeting meeting) {
            throw new NotImplementedException();
        }

        public Task DeleteMeeting(int meetingId) {
            throw new NotImplementedException();
        }

        public Task<Meeting> GetMeetingById(int meetingId) {
            throw new NotImplementedException();
        }

        public Task<List<Meeting>> GetMeetingList() {
            throw new NotImplementedException();
        }

        public Task UpdateMeeting(Meeting meeting) {
            throw new NotImplementedException();
        }
    }
}
