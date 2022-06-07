import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.registerForm= this.fb.group({
      'username': [''],
      'password': [''],
      'password2': [''],
    })
  }

  ngOnInit(): void {
  }

  register(){
    console.log(this.registerForm.value)
  }

}
