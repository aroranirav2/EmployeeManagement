import { createFeatureSelector, createSelector } from "@ngrx/store";
import { departmentsFeatureKey, DepartmentState, selectAll } from "./department.reducer";

export const selectDepartmentState = createFeatureSelector<DepartmentState>(
    departmentsFeatureKey
)

export const  selectDepartments = createSelector(selectDepartmentState, selectAll);