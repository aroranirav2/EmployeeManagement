import { createReducer, on } from '@ngrx/store';
import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { Department } from '../models/department.model';
import * as DepartmentActions from './department.actions';

export const departmentsFeatureKey = 'departments';

export interface DepartmentState extends EntityState<Department> {
  error: any
}

export const adapter: EntityAdapter<Department> = createEntityAdapter<Department>();

export const initialState: DepartmentState = adapter.getInitialState({
  error: undefined
});

export const reducer = createReducer(
  initialState,
  on(DepartmentActions.addDepartmentSuccess,
    (state, action) => adapter.addOne(action.department, state)
  ),
  on(DepartmentActions.addDepartmentFailure,
    (state, action) => {
      return {
        ...state,
        error: action.error
      }
    }
  ),
  on(DepartmentActions.loadDepartmentsSuccess,
    (state, action) => adapter.addMany(action.departments, state)
  ),
  on(DepartmentActions.loadDepartmentsFailure,
    (state, action) => {
      return {
        ...state,
        error: action.error
      }
    }
  ),
  on(DepartmentActions.upsertDepartment,
    (state, action) => adapter.upsertOne(action.department, state)
  ),
  on(DepartmentActions.addDepartments,
    (state, action) => adapter.addMany(action.departments, state)
  ),
  on(DepartmentActions.upsertDepartments,
    (state, action) => adapter.upsertMany(action.departments, state)
  ),
  on(DepartmentActions.updateDepartment,
    (state, action) => adapter.updateOne(action.department, state)
  ),
  on(DepartmentActions.updateDepartments,
    (state, action) => adapter.updateMany(action.departments, state)
  ),
  on(DepartmentActions.deleteDepartment,
    (state, action) => adapter.removeOne(action.id, state)
  ),
  on(DepartmentActions.deleteDepartments,
    (state, action) => adapter.removeMany(action.ids, state)
  ),
  on(DepartmentActions.clearDepartments,
    state => adapter.removeAll(state)
  ),
);

export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapter.getSelectors();
