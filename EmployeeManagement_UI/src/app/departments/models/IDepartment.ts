import { Guid } from "guid-typescript";
import { IEmployee } from "src/app/employees/models/IEmployee";

export interface IDepartment {
    departmentId: Guid;
    departmentName: string;
    employees: IEmployee[];
}