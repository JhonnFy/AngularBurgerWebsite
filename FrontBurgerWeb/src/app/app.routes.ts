import { Routes } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';
import { Menu } from './menu/menu';
import { About } from './about/about';
import { Reviews } from './reviews/reviews';
import { Contact } from './contact/contact';
import { Blogs } from './blogs/blogs';


export const routes: Routes = [
    { path: '', component: Dashboard },
    { path: 'menu',component: Menu },
    { path: 'about', component: About },
    { path: 'reviews', component: Reviews },
    { path: 'contact', component: Contact },
    { path: 'blogs', component: Blogs }
];
