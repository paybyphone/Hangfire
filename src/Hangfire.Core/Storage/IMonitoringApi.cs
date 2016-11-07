// This file is part of Hangfire.
// Copyright © 2013-2014 Sergey Odinokov.
//
// Hangfire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as
// published by the Free Software Foundation, either version 3
// of the License, or any later version.
//
// Hangfire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with Hangfire. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using Hangfire.Storage.Monitoring;

namespace Hangfire.Storage
{
    public interface IMonitoringApi
    {
        IList<QueueWithTopEnqueuedJobsDto> Queues();
        IList<ServerDto> Servers();
        JobDetailsDto JobDetails(string jobId);
        StatisticsDto GetStatistics();

        JobList<EnqueuedJobDto> EnqueuedJobs(string queue, int from, int perPage, string jobIdFilter = null);
        JobList<FetchedJobDto> FetchedJobs(string queue, int from, int perPage, string jobIdFilter = null);

        JobList<ProcessingJobDto> ProcessingJobs(int from, int count, string jobIdFilter = null);
        JobList<ScheduledJobDto> ScheduledJobs(int from, int count, string jobIdFilter = null);
        JobList<SucceededJobDto> SucceededJobs(int from, int count, string jobIdFilter = null);
        JobList<FailedJobDto> FailedJobs(int from, int count, string jobIdFilter = null);
        JobList<DeletedJobDto> DeletedJobs(int from, int count, string jobIdFilter = null);

        long ScheduledCount(string jobIdFilter = null);
        long EnqueuedCount(string queue, string jobIdFilter = null);
        long FetchedCount(string queue, string jobIdFilter = null);
        long FailedCount(string jobIdFilter = null);
        long ProcessingCount(string jobIdFilter = null);

        long SucceededListCount(string jobIdFilter = null);
        long DeletedListCount(string jobIdFilter = null);

        IDictionary<DateTime, long> SucceededByDatesCount(string jobIdFilter = null);
        IDictionary<DateTime, long> FailedByDatesCount(string jobIdFilter = null);
        IDictionary<DateTime, long> HourlySucceededJobs(string jobIdFilter = null);
        IDictionary<DateTime, long> HourlyFailedJobs(string jobIdFilter = null);
    }
}