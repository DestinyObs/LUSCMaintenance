using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using LUSCMaintenance.Interfaces;
using LUSCMaintenance.Models;
using LUSCMaintenance.Repositories;

namespace LUSCMaintenance
{
    public class MaintenanceReportService
    {
        private readonly IMaintenanceProblemRepository _maintenanceProblemRepository;
        private readonly EmailService _emailService;

        public MaintenanceReportService(IMaintenanceProblemRepository maintenanceProblemRepository, EmailService emailService)
        {
            _maintenanceProblemRepository = maintenanceProblemRepository;
            _emailService = emailService;
        }

        public async Task GenerateAndSendMaintenanceReports()
        {
            try
            {
                // Retrieve maintenance problems with related issues and categories
                var maintenanceProblems = await _maintenanceProblemRepository.GetAllMaintenanceProblemsWithRelatedDataAsync();

                // Group maintenance problems by hostel
                var groupedProblems = maintenanceProblems.GroupBy(p => p.Hostel);

                // Generate Excel files for each hostel
                foreach (var group in groupedProblems)
                {
                    // Create a new Excel workbook
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Maintenance Problems");

                    // Add headers to the worksheet
                    worksheet.Cell(1, 1).Value = "WebMail";
                    worksheet.Cell(1, 2).Value = "Block";
                    worksheet.Cell(1, 3).Value = "Room Number";
                    worksheet.Cell(1, 4).Value = "Time Available";
                    worksheet.Cell(1, 5).Value = "Date Complaint Made";
                    worksheet.Cell(1, 6).Value = "Is Resolved";
                    worksheet.Cell(1, 7).Value = "Issues";

                    // Populate data rows
                    int row = 2;
                    foreach (var problem in group)
                    {
                        // Concatenate issue descriptions
                        var issues = string.Join(", ", problem.MaintenanceProblemIssues.Select(pi => pi.MaintenanceIssue.Description));

                        worksheet.Cell(row, 1).Value = problem.WebMail;
                        worksheet.Cell(row, 2).Value = problem.Block;
                        worksheet.Cell(row, 3).Value = problem.RoomNumber;
                        worksheet.Cell(row, 4).Value = problem.TimeAvailable;
                        worksheet.Cell(row, 5).Value = problem.DateComplaintMade;
                        worksheet.Cell(row, 6).Value = problem.IsResolved ? "Yes" : "No";
                        worksheet.Cell(row, 7).Value = issues;
                        row++;
                    }

                    // Save the workbook to a memory stream
                    using var stream = new MemoryStream();
                    workbook.SaveAs(stream);

                    // Send the Excel file as an email attachment
                    // Send the Excel file as an email attachment to multiple recipients
                    var recipients = new List<string> { "vcmlusc@lmu.edu.ng", "obueh.destiny@lmu.edu.ng" };
                    await SendEmailWithAttachment(recipients, stream.ToArray());
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private async Task SendEmailWithAttachment(IEnumerable<string> recipients, byte[] attachment)
        {
            foreach (var recipient in recipients)
            {
                var recipientList = new List<string> { recipient }; // Wrap the recipient into a collection
                await _emailService.SendEmailAsync(recipientList, "Maintenance Report", "Please find attached maintenance report.", attachment);
            }
        }


    }
}
