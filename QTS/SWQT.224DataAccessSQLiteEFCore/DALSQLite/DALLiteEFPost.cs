using AutoMapper;
using SWQT._224DataAccessSQLiteEFCore.EFCore;
using SWQT._512ViewModels.Admin.Post;
using SWQT._576Entity.Entities;

namespace SWQT._224DataAccessSQLiteEFCore.DALSQLite
{
    public class DALLiteEFPost
    {

        public bool BlnUpdateListSuccess(List<TblListPost> lstInput)
        {
            var mMapper = new Mapper(new MapperConfiguration(
                x => {
                    x.CreateMap<TblListPost, TblListPost>()
                    .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                    .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                    .ForMember(x => x.Name, opt => opt.Ignore())
                    .ForMember(x => x.Json, opt => opt.Ignore())
                    .ForMember(x => x.Status, opt => opt.Ignore())
                    ;
                }));
            using (var mainContext = new SWQTDbContext())
            {
                foreach (var item in lstInput)
                {
                    TblListPost mRow = mainContext.TblListPost!.Find(item.Id)!;
                    //mRow = mMapper.Map<TblListPost>(item);
                    mMapper.Map<TblListPost,TblListPost>(item, mRow);
                }
                mainContext.SaveChanges();
                return true;
            }
        }

        public bool BlnSuccessDeleteByListId(List<int> lstInput)
        {
            var lstLongInput = new List<long>();
            foreach (var item in lstInput)
            {
                lstLongInput.Add(item);
            }
            using (var mainContext = new SWQTDbContext())
            {
                mainContext.TblListPost!.RemoveRange(
                    mainContext.TblListPost!
                    .Where(r => lstLongInput.Contains(r.Id)));
                mainContext.SaveChanges();
                return true;
            }
        }

        public int IntTotalRow()
        {
            using (var mainContext = new SWQTDbContext() )
            {
                return mainContext.TblListPost!.Count();
            }
        }

        public List<TblListPost> LstByListId(List<int> lstInput)
        {
            var lstLongInput = new List<long>();
            foreach (var item in lstInput)
            {
                lstLongInput.Add(item);
            }
            using (var mainContext = new SWQTDbContext())
            {
                return mainContext.TblListPost!
                    .Where(r => lstLongInput.Contains(r.Id)).ToList();
            }
        }

        public List<TblListPost> LstByPageAndSize(VMGetPostPaging mRequest)
        {
            using (var mainContext = new SWQTDbContext())
            {
                return mainContext.TblListPost!
                    .OrderByDescending(x => x.Id)
        .Skip((mRequest.IntPageIndex - 0) * mRequest.IntPageSize).Take(mRequest.IntPageSize).ToList();
            }
        }
    }
}
