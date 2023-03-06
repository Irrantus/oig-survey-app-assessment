using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuestionnaireApi.Data.Entities;

namespace QuestionnaireApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options)
                : base(options)
        {
        }

        public DbSet<Questionnaire> Questionnaires { get; set; }
    }
}
