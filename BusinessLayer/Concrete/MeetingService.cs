using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos.MeetingDtos;
using EntityLayer.Dtos.MeetingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class MeetingService : IMeetingService {

        private readonly IMeetingRepository meetingRepository;
        private readonly IMapper mapper;

        public MeetingService(IMeetingRepository meetingRepository, IMapper mapper) {
            this.meetingRepository = meetingRepository;
            this.mapper = mapper;
        }

        public async Task AddMeeting(CreateMeetingDto createMeetingDto) {
            var value = mapper.Map<Meeting>(createMeetingDto);
            await meetingRepository.AddAsync(value);
        }

        public async Task DeleteMeetingById(int meetingId) {
            await meetingRepository.DeleteAsync(u => u.Id == meetingId);
        }

        public async Task<ResultMeetingDto> GetByIdMeeting(int meetingId) {
            var meeting = await meetingRepository.GetAsync(u => u.Id == meetingId);
            return mapper.Map<ResultMeetingDto>(meeting);
        }

        public async Task<List<Meeting>> GetMeetingList() { // TO DO : CHange return type to result meeting dto
            return await meetingRepository.ListAsync(b => true);
        }

        public async Task UpdateMeeting(UpdateMeetingDto updateMeetingDto) {
            var meeting = mapper.Map<Meeting>(updateMeetingDto);
            await meetingRepository.UpdateAsync(meeting);
        }
    }
}
