using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.InfraStructure.Migrations
{
    public partial class userAnaltics_view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW V_UserAnalytics AS
                                        SELECT 
                                            r.UserEmail,
            
                                            DATEDIFF(DAY, r.Date, r2.Date) AS DaysBetweenTrips,
                                            t1.PickUp AS pickup,
                                            t1.Destination AS destination
                                        FROM 
                                            Reservations r
	                                   Join Reservations r2 on r.TripRouteId = r2.TripRouteId
							                                   AND r.UserEmail = r2.UserEmail
							                                   AND r.Date < r2.Date
                                        JOIN 
                                            TripRoutes t1 ON r.TripRouteId = t1.Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS V_UserAnalytics;");

        }
    }
}
