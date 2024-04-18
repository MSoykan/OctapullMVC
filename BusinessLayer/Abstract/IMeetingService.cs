using EntityLayer.Concrete;
using EntityLayer.Dtos.MeetingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface IMeetingService {
        Task AddMeeting(CreateMeetingDto createMeetingDto);
        Task UpdateMeeting(UpdateMeetingDto updateMeetingDto);
        Task DeleteMeetingById(int meetingId);
        Task<ResultMeetingDto> GetByIdMeeting(int meetingId);
        Task<List<Meeting>> GetMeetingList();
    }
}
