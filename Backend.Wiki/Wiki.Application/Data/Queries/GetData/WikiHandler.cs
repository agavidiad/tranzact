using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wiki.Application.Data.Queries.GetData
{
    public class WikiHandler : IRequestHandler<WikiRequest, IEnumerable<WikiResponse>>
    {

        public async Task<IEnumerable<WikiResponse>> Handle(WikiRequest request, CancellationToken cancellationToken)
        {

            IEnumerable<WikiResponse> result = new List<WikiResponse>();

            var fileContents = await GetData(Shared.Files.Functions.GetFileContent(request.compressedFilePath, request.directoryPath));

            if (fileContents.Count() > 0)
            {
                result = (from fc in fileContents
                         group fc by new
                         {
                             fc.DOMAIN_CODE,
                             fc.PAGE_TITLE
                         } into g
                         select new WikiResponse
                         {
                             DOMAIN_CODE = g.First().DOMAIN_CODE,
                             PAGE_TITLE = g.First().PAGE_TITLE,
                             CNT = g.Sum(pc => pc.CNT),
                         }).OrderByDescending(f => f.CNT).Take(100);
            }
            return result;
        }

        public async Task<IEnumerable<WikiResponse>> GetData(List<string> fileContents)
        {
            List<WikiResponse> result = new List<WikiResponse>();
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < fileContents.Count(); i++)
                {
                    string[] row = fileContents[i].Split(' ');
                    if (row.Length > 2)
                        result.Add(new WikiResponse()
                        {
                            DOMAIN_CODE = row[0],
                            PAGE_TITLE = row[1],
                            CNT = row[2] != null ? Convert.ToInt32(row[2]) : 0,
                        });
                }
            });
            return result;

        }
    }
}
