using Business.Dtos.Requests.AnnouncementProjectRequests;
using Business.Dtos.Responses.AnnouncementProjectResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAnnouncementProjectService
    {
        Task<CreatedAnnouncementProjectResponse> AddAsync(CreateAnnouncementProjectRequest createAnnouncementProjectRequest);
        Task<UpdatedAnnouncementProjectResponse> UpdateAsync(UpdateAnnouncementProjectRequest updateAnnouncementProjectRequest);

        Task<DeletedAnnouncementProjectResponse> DeleteAsync(DeleteAnnouncementProjectRequest deleteAnnouncementProjectRequest);

        Task<IPaginate<GetListAnnouncementProjectResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListAnnouncementProjectResponse> GetByIdAsync(Guid Id);


    }
}
