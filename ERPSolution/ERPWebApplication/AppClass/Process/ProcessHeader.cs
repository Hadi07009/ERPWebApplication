using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///  Created by:     Hadi             Date: 21-August-2013
/// Task No:        02
/// Objectives:      
/// Reviewed by:
/// 
/// Modified By                     Date                Purpose
/// ===============================================================================================
/// 
/// 
/// 
/// 
/// ===============================================================================================
/// Link3 Technologies Ltd
/// </summary>
public class ProcessHeader
{
    public ProcessHeader()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string ProcessId { get; set; }
    public string ProcessDescription { get; set; }
    public string Status { get; set; }
    public int CategoryId { get; set; }
    public int ProcessFlowId { get; set; }
    public string FlowDescription { get; set; }
    public string LevelDescription { get; set; }
    public int ProcessLevelId { get; set; }
    public string Action { get; set; }
    public int ActionTypeId { get; set; }
    public string ReferenceNo { get; set; }
    public string DepartmentId { get; set; }
    public string AccessId { get ; set ;}
    public string SubAccessId { get; set; }
    public string AccessPermissionTypeID { get; set; }
    public string SubAccessPermissionTypeID { get; set; }
    public string SuperUserID { get; set; }
    public string MonitoringId { get; set; }
    public string ApplicantID { get; set; }
    public string Tag { get; set; }
    public string ProcessName { get; set; }

}
