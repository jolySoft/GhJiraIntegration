using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GhJiraIntegration.Models
{
    public class GitWebhookBranchCompareResponse
    {
            public string url { get; set; }
            public string html_url { get; set; }
            public string permalink_url { get; set; }
            public string diff_url { get; set; }
            public string patch_url { get; set; }
            public Base_Commit base_commit { get; set; }
            public Merge_Base_Commit merge_base_commit { get; set; }
            public string status { get; set; }
            public int ahead_by { get; set; }
            public int behind_by { get; set; }
            public int total_commits { get; set; }
            public Commit2[] commits { get; set; }
            public File[] files { get; set; }
        }

        public class Base_Commit
        {
            public string sha { get; set; }
            public string node_id { get; set; }
            public Commit commit { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string comments_url { get; set; }
            public object author { get; set; }
            public object committer { get; set; }
            public Parent[] parents { get; set; }
        }

        public class Commit
        {
            public Author author { get; set; }
            public Committer committer { get; set; }
            public string message { get; set; }
            public Tree tree { get; set; }
            public string url { get; set; }
            public int comment_count { get; set; }
            public Verification verification { get; set; }
        }

        public class Author
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
        }

        public class Committer
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
        }

        public class Tree
        {
            public string sha { get; set; }
            public string url { get; set; }
        }

        public class Verification
        {
            public bool verified { get; set; }
            public string reason { get; set; }
            public object signature { get; set; }
            public object payload { get; set; }
        }

        public class Parent
        {
            public string sha { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
        }

        public class Merge_Base_Commit
        {
            public string sha { get; set; }
            public string node_id { get; set; }
            public Commit1 commit { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string comments_url { get; set; }
            public object author { get; set; }
            public object committer { get; set; }
            public Parent1[] parents { get; set; }
        }

        public class Commit1
        {
            public Author1 author { get; set; }
            public Committer1 committer { get; set; }
            public string message { get; set; }
            public Tree1 tree { get; set; }
            public string url { get; set; }
            public int comment_count { get; set; }
            public Verification1 verification { get; set; }
        }

        public class Author1
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
        }

        public class Committer1
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
        }

        public class Tree1
        {
            public string sha { get; set; }
            public string url { get; set; }
        }

        public class Verification1
        {
            public bool verified { get; set; }
            public string reason { get; set; }
            public object signature { get; set; }
            public object payload { get; set; }
        }

        public class Parent1
        {
            public string sha { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
        }

        public class Commit2
        {
            public string sha { get; set; }
            public string node_id { get; set; }
            public Commit3 commit { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string comments_url { get; set; }
            public object author { get; set; }
            public object committer { get; set; }
            public Parent2[] parents { get; set; }
        }

        public class Commit3
        {
            public Author2 author { get; set; }
            public Committer2 committer { get; set; }
            public string message { get; set; }
            public Tree2 tree { get; set; }
            public string url { get; set; }
            public int comment_count { get; set; }
            public Verification2 verification { get; set; }
        }

        public class Author2
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
        }

        public class Committer2
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
        }

        public class Tree2
        {
            public string sha { get; set; }
            public string url { get; set; }
        }

        public class Verification2
        {
            public bool verified { get; set; }
            public string reason { get; set; }
            public object signature { get; set; }
            public object payload { get; set; }
        }

        public class Parent2
        {
            public string sha { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
        }

        public class File
        {
            public string sha { get; set; }
            public string filename { get; set; }
            public string status { get; set; }
            public int additions { get; set; }
            public int deletions { get; set; }
            public int changes { get; set; }
            public string blob_url { get; set; }
            public string raw_url { get; set; }
            public string contents_url { get; set; }
            public string patch { get; set; }
            public string previous_filename { get; set; }
        }
}
