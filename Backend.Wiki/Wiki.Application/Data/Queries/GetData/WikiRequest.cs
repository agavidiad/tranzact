using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki.Application.Data.Queries.GetData
{
    public  class WikiRequest: IRequest<IEnumerable<WikiResponse>>
    {
        public int lastHours { get; set; }
        public string directoryPath { get; set; }
        public string compressedFilePath { get; set; }
        
    }
}
