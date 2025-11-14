import { Routes } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';
import { Menu } from './menu/menu';


export const routes: Routes = [
    { path: '', component: Dashboard },
    { path: 'menu',component: Menu }
];
