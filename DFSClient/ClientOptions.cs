﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSClient
{
    class Options
    {
        public Options()
        {
            ListingVerb = new ListingSubOptions();
        }

        [HelpVerbOption]
        public string GetUsage(string s)
        {
            return "Help Text";
        }

        [VerbOption("ls", HelpText = "List directory contents")]
        public ListingSubOptions ListingVerb { get; set; }

        [VerbOption("put", HelpText = "Add a file")]
        public PutSubOptions PutVerb { get; set; } 

        [VerbOption("rm", HelpText = "Delete a file or directory")]
        public DeleteSubOptions DeleteVerb { get; set; }

        [VerbOption("mkdir", HelpText = "Create a directory")]
        public MkdirSubOptions MkdirVerb { get; set; }
    }
}
