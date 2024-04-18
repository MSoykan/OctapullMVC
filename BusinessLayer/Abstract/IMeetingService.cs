using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface IMeetingService {
        Task AddMeeting(Meeting meeting);
        Task UpdateMeeting(Meeting meeting);
        Task DeleteMeeting(int meetingId);
        Task<Meeting> GetMeetingById(int meetingId);
        Task<List<Meeting>> GetMeetingList();
    }
}
