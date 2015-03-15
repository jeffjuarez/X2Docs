using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapping
{
    public class FileUploadMap : EntityTypeConfiguration<FileUpload>
    {
        public FileUploadMap()
        {
            // Primary Key
            HasKey(t => t.FileUploadID);

            // Properties
            Property(t => t.FileName)
                .IsRequired()
                .HasMaxLength(250);

            Property(t => t.FileType)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            ToTable("FileUploads");
            Property(t => t.FileUploadID).HasColumnName("ID");
            Property(t => t.FileName).HasColumnName("Name");
            Property(t => t.FileType).HasColumnName("Type");
            Property(t => t.FileContent).HasColumnName("Content");
        }
    }
}
