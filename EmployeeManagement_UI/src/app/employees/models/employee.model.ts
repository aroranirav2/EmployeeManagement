import { Guid } from "guid-typescript";
import { Department } from "src/app/departments/models/department.model";

export interface Employee{
    employeeId: Guid;
    firstName: string;
    lastName: string;
    gender: string;
    department: Department;
}