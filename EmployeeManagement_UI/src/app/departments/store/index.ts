import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from '../../../environments/environment';

export const departmentStateFeatureKey = 'departmentState';

export interface DepartmentState {

}

export const reducers: ActionReducerMap<DepartmentState> = {

};


export const metaReducers: MetaReducer<DepartmentState>[] = !environment.production ? [] : [];
