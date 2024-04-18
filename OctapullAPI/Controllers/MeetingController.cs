using BusinessLayer.Abstract;
using EntityLayer.Dtos.MeetingDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OctapullAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase {

        private readonly IMeetingService meetingService;

        public MeetingController(IMeetingService meetingService) {
            this.meetingService = meetingService;
        }
        [HttpGet]
        public async Task<IActionResult> MeetingList() {
            var values = await meetingService.GetMeetingList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetingById(int id) {
            var values = await meetingService.GetByIdMeeting(id);
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMeetingById(int id) {
            await meetingService.DeleteMeetingById(id);
            return Ok("Meeting with id " + id + " has been deleted succesfully");
        }
        [HttpPost]
        public async Task<IActionResult> AddMeeting(CreateMeetingDto createMeetingDto) {
            await meetingService.AddMeeting(createMeetingDto);
            return Ok("Meeting has been added succesfully.Meeting Added: \n" + createMeetingDto.ToString());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMeeting(UpdateMeetingDto updateMeetingDto) {
            await meetingService.UpdateMeeting(updateMeetingDto);
            return Ok("Meeting with id " + updateMeetingDto.Id + " has been updated succesfully. New use: " + updateMeetingDto.ToString());
        }

    }
}
