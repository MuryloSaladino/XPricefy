import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService, LoginPayload } from "src/app/core/services/auth.service";
import { PopulateService } from "src/app/core/services/populate.service";

@Component({
    selector: "app-login",
    templateUrl: "./login.page.html",
    styleUrls: ["login.page.css"]
})
export class LoginPage implements OnInit {

    loginForm!: FormGroup;
    loading: boolean = false;
    populatedAccess: LoginPayload | null = null;

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly authService: AuthService,
        private readonly router: Router,
        readonly populateService: PopulateService,
    ) {}

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            username: [null, Validators.required],
            password: [null, Validators.required]
        })
    }

    async doLogin() {
        const username = this.loginForm.value.username;
        const password = this.loginForm.value.password;

        try {
            await this.authService.login(username, password);
            this.router.navigate(["/"])
        } catch {
            
        }
    }

    async populate() {
        this.loading = true;
        this.populatedAccess = await this.populateService.populate();
        this.loading = false;
    }

    writeToFields() {
        if (this.populatedAccess) {
            this.loginForm.patchValue({
                username: this.populatedAccess.username,
                password: this.populatedAccess.password
            });
        }
    }
}