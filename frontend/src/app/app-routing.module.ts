import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPage } from './pages/login/login.page';
import { HomePage } from './pages/home/home.page';
import { authGuard } from './core/guards/auth.guard';

const routes: Routes = [
    {
        path: "login",
        component: LoginPage,
    },
    {
        path: "",
        component: HomePage,
        canActivate: [authGuard]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
