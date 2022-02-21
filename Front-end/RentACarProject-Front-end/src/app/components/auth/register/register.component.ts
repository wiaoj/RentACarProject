import { Router } from '@angular/router';
import { LocalStorageService } from './../../../services/localStorage/local-storage.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../../../services/auth/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService,
    private localStorageService:LocalStorageService,
    private router:Router
  ) {}

  ngOnInit(): void {this.createRegisterForm()}

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      emailAdress: ['', Validators.required, ],
      password: ['', Validators.required,Validators.minLength(8),Validators.maxLength(50)],
    });
  }

  register() {
    if (this.registerForm.valid) {
      console.log(this.registerForm.value);
      let registerModel = Object.assign({}, this.registerForm.value);

      this.authService.register(registerModel).subscribe(
        (response) => {
          this.toastr.info(response.message)
          this.router.navigate([""]);
          this.localStorageService.add('token', response.data.token)
        },
        (responseError) => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
              this.toastr.error(responseError.error.ValidationErrors[i].ErrorMessage);
            }
          }
        }
      );
    } else {
      this.toastr.error('Formunuz eksik', 'Dikkat');
    }
  }
}
