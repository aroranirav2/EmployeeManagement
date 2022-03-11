import { Guid } from "guid-typescript";
import { IDepartment } from "src/app/departments/models/IDepartment";

export interface IEmployee{
    employeeId: Guid;
    firstName: string;
    lastName: string;
    department: IDepartment;
}