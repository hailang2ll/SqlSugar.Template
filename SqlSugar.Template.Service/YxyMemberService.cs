using DMS.Common.Helper;
using DMS.Common.Model.Result;
using SqlSugar.Template.IService;
using SqlSugar.Template.IService.Param;
using SqlSugar.Template.IService.Result;
using SqlSugar.Template.Models;
using SqlSugar.Template.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SqlSugar.Template.Service
{
    public class YxyMemberService : BaseRepository<YxyMember>, IYxyMemberService
    {
        /// <summary>
        /// 同库事物
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseResult> Add(AddMemberParam param)
        {
            ResponseResult result = new ResponseResult() { errmsg = "新增数据" };
            try
            {
                itenant.BeginTran();

                YxyMember member = new YxyMember()
                {
                    MemberName = param.MemberName,
                    Password = "",
                    PasswordType = 1,
                    TrueName = param.TrueName,
                    Mobile = param.Mobile,
                    MobileFlag = 1,
                    Email = "",
                    EmailFlag = 1,
                    SexType = 1,
                    Qq = "",
                    StatusFlag = 1,
                    DisableReason = "",
                    CardImagePath = "",
                    CreateTime = DateTime.Now,
                    ChannelType = 1,
                };
                await base.InsertAsync(member);
                await base.UpdateAsync(q => new YxyMember() { TrueName = "xingsk0" }, q => q.Id == 50003);

                itenant.CommitTran();
            }
            catch (Exception ex)
            {
                itenant.RollbackTran();
                throw;
            }
            return result;

        }
        /// <summary>
        /// 切换仓库，不同库事物
        /// </summary>
        public async Task<ResponseResult> AddTran(AddMemberParam param)
        {
            ResponseResult result = new();
            try
            {
                itenant.BeginTran();
                YxyMember member = new YxyMember()
                {
                    MemberName = param.MemberName,
                    Password = "",
                    PasswordType = 1,
                    TrueName = param.TrueName,
                    Mobile = param.Mobile,
                    MobileFlag = 1,
                    Email = "",
                    EmailFlag = 1,
                    SexType = 1,
                    Qq = "",
                    StatusFlag = 1,
                    DisableReason = "",
                    CardImagePath = "",
                    CreateTime = DateTime.Now,
                    ChannelType = 1,
                };
                await base.InsertAsync(member);
                var joblogDal = base.ChangeRepository<BaseRepository<SysJoblog>>();//切换仓储
                SysJoblog joblog = new()
                {
                    Name = param.MemberName,
                    JobLogtype = 1,
                    ServerIp = IPHelper.GetCurrentIp(),
                    TaskLogtype = 1,
                    Message = "我是会员事物",
                    CreateTime = DateTime.Now,
                };
                await joblogDal.InsertAsync(joblog);

                itenant.CommitTran();
            }
            catch (Exception ex)
            {
                itenant.RollbackTran();
            }
            return result;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseResult> GetEntity(long id)
        {
            ResponseResult result = new ResponseResult() { errmsg = "获取用户信息" };
            if (id <= 0)
            {
                result.errno = 1;
                result.errmsg = "参数错误";
                return result;
            }
            //实体
            var entity = await base.GetByIdAsync(id);
            entity = await base.GetSingleAsync(it => it.Id == id);//查询单条记录，结果集不能超过1，不然会提示错误
            entity = await base.GetFirstAsync(it => it.Id == id);//查询第一条记录

            //指定返回实体，一种
            var centity = await base.GetEntity<YxyMemberResult>(q => q.Id == id);
            //二种
            centity = await base.GetEntity(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, q => q.Id == id);
            var bentity = await base.GetEntity(q => new { q.Id, q.MemberName, q.Mobile }, q => q.Id == id);
            //通用
            centity = await Context.Queryable<YxyMember>()
               .Select<YxyMemberResult>()
               .FirstAsync(q => q.Id > 0);
            if (entity == null)
            {
                result.errno = 1;
                result.errmsg = "未找到相关数据";
                return result;
            }

            result.data = centity;
            return result;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseResult> GetList(long id)
        {
            ResponseResult result = new() { errmsg = "获取用户信息" };
            var list = await base.GetListAsync();//查询所有
            list = await base.GetListAsync(q => q.Id > 50000);
            //以下扩展
            list = await base.QueryList("id desc");
            list = await base.QueryList(q => q.Id > 4000, "id desc");
            list = await base.QueryList(q => q.Id > 4000, q => q.Id, false);



            //自定义实体
            var clist = await base.QueryList<YxyMemberResult>();
            clist = await base.QueryList<YxyMemberResult>(q => q.Id > 50000);
            clist = await base.QueryList<YxyMemberResult>("id desc");
            clist = await base.QueryList<YxyMemberResult>(q => q.Id, false);
            clist = await base.QueryList<YxyMemberResult>(q => q.Id > 100, "id desc");
            clist = await base.QueryList<YxyMemberResult>(q => q.Id > 100, q => q.Id, false);


            clist = await base.QueryList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName });
            clist = await base.QueryList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, q => q.Id > 50000);
            clist = await base.QueryList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, "id desc");
            clist = await base.QueryList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, q => q.Id, false);
            clist = await base.QueryList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, q => q.Id > 100, "id desc");
            clist = await base.QueryList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, q => q.Id > 100, q => q.Id, false);
            clist = await Context.Queryable<YxyMember>()
                .Where(q => q.Id > 0)
                .OrderBy(q => q.Id)
                .Select<YxyMemberResult>()
                .ToListAsync();
            if (list == null || list.Count <= 0)
            {
                result.errno = 2;
                result.errmsg = "未找到相关数据";
                return result;
            }
            result.data = clist;
            return result;
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResponseResult> GetList(SearchMemberParam param)
        {
            ResponseResult result = new();
            if (param == null)
            {
                result.errno = 1;
                result.errmsg = "参数不合法";
                return result;
            }

            var list = await base.QueryList(q => q.Id > 100, param);
            list = await base.QueryList(q => q.Id > 100, param, "id desc");

            var pageList = await base.QueryPageList(q => q.Id > 100, param);
            pageList = await base.QueryPageList(q => q.Id > 100, param, "id desc");

            pageList = await base.QueryPageList(q => q.Id > 100, param, q => q.Id, false);

            var cpageList = await base.QueryPageList<YxyMemberResult>(q => q.Id > 100, param);

            cpageList = await base.QueryPageList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, q => q.Id > 100, param);
            cpageList = await base.QueryPageList(q => new YxyMemberResult() { Id = q.Id, MemberName = q.MemberName }, q => q.Id > 100, param, "id desc");


            RefAsync<int> totalCount = 0;
            var expression = Expressionable.Create<YxyMember>();
            expression.And(m => m.Id == 1);
            Expression<Func<YxyMember, bool>> where = expression.ToExpression();
            var bpageList = await Context.Queryable<YxyMember>()
                 .WhereIF(where != null, where)
                 .OrderBy(q => q.Id, OrderByType.Desc)
                 .Select<YxyMemberResult>()
                 .ToPageListAsync(param.pageIndex, param.pageSize, totalCount);
            if (list == null || list.Count <= 0)
            {
                result.errno = 2;
                result.errmsg = "未找到相关数据";
                return result;
            }
            result.data = cpageList;
            return result;
        }


    }
}
