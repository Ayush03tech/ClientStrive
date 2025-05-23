export interface IRole {
    roleId: number;
    roleName : string;
}

export interface IDesignation {
    designationId: number;
    designation: string;
}

export interface APIResponseModel {
    message: string;
    result: boolean;
    data: any;
}

export interface IEmployee{
    empName: string;
    empId: number;
    empCode: string;
    empEmailId: string;
    empDesignation: string;
    role: string
}