import { Component, OnInit, Inject, ViewChild } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { NgForm, FormGroup, Validators, FormBuilder } from "@angular/forms";
import { DetailService } from "../../shared/detail.service";
import { ToastrService } from "ngx-toastr";
import { HttpEventType, HttpClient } from "@angular/common/http";

import { faWindowClose } from "node_modules/@fortawesome/free-solid-svg-icons";
import { EmployeeService } from '../../shared/employee.service';
@Component({
  selector: "app-add-message",
  templateUrl: "./add-message.component.html",
  styleUrls: ["./add-message.component.css"],
  providers: [DetailService]
})
export class AddMessageComponent implements OnInit {
  messageForm: FormGroup;
  documentForm: FormGroup;
  employeeForm: FormGroup;
  faWindowClose = faWindowClose;

  documentFile: File;
  ArrayOfFiles: any[] = [];
  selectedFile: File;
  fileList: File[] = [];
  employeePicture: File;

  submitted = false;
  constructor(
    public dialogRef: MatDialogRef<AddMessageComponent>,
    public service: DetailService,
    public serviceEmp: EmployeeService,
    public toastr: ToastrService,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit() {
    this.resetForm();
    this.messageForm = this.formBuilder.group({
      TextMessage: ["", Validators.required],
      Group: ["", Validators.required],
      Email: localStorage.getItem("upn"),
      AttachmentIds: [],
    });

    this.employeeForm = this.formBuilder.group({
      EmailEmployee: ["", Validators.required],
      Firstname: ["", Validators.required],
      Lastname: ["", Validators.required],
      Phone: ["", Validators.required],
    });

    this.documentForm = this.formBuilder.group({
      Title: ["", Validators.required],
      Attachment: [],
    });
  }
  get f() {
    return this.messageForm.controls;
  }
  closeClick(): void {
    this.dialogRef.close();
  }
  clearMessageForm() {
    this.messageForm.reset({
      TextMessage: "",
      Group: "",
      fileUpload: ""
    });
  }

  clearDocumentForm() {
    this.documentForm.reset({
      Title: "",
      Attachment: ""
    });
  }
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  uploadFileSave(e) {
    if (e.length != 0) {
      this.ArrayOfFiles.push(e[0]);
    }
  }

  uploadDoc(e) {
    if (e.length != null)
      this.documentFile = e;
      console.log(e);
  }
  // uploadEmployeePicture(e) {
  //   if (e.length != 0) {
  //     this.selectedFile = e;
  //   }
  // }

  remove(fileToRemove) {
    for (var i = 0; i < this.ArrayOfFiles.length; i++) {
      if (this.ArrayOfFiles[i] == fileToRemove) this.ArrayOfFiles.splice(i, 1);
    }
  }

  removeDoc(fileToRemove) {
    if (this.documentFile == fileToRemove) this.documentFile = null;
  }

  onSubmit() {
    this.submitted = true;
    if (this.messageForm.invalid) {
      return;
    }
    this.service.postMessageDetails(this.messageForm.value, this.ArrayOfFiles).subscribe(res => {
      this.clearMessageForm();
      this.toastr.success("Uspješno");
      this.resetForm();
      this.service.refreshMessageList();
      this.closeClick();
    },
      err => {
        this.toastr.error("Pokušajte ponovo", "Došlo je do greške");
      });
  }

  onSubmitDocument() {
    this.submitted = true;
    if (this.documentForm.invalid) {
      return;
    }
    this.service.postdocument(this.documentForm.value, this.documentFile).subscribe(res => {
      this.clearDocumentForm();
      this.toastr.success("Uspješno");
      this.resetForm();
      this.service.refreshMessageList();
      this.closeClick();
    },
      err => {
        this.toastr.error("Pokušajte ponovo", "Došlo je do greške");
      });
  }

  // onSubmit(type: string) {
  //   this.submitted = true;
  //   if (this.messageForm.invalid || this.employeeForm.invalid) {
  //     return;
  //   }

  //   console.log(type);

  //   switch (type) {
  //     case 'prijedlozi': {
  //       this.service.postMessageDetails(this.messageForm.value, this.ArrayOfFiles).subscribe(res => {
  //         this.clearMessageForm();
  //         this.toastr.success("Uspješno");
  //         this.resetForm();
  //         this.service.refreshMessageList();
  //         this.closeClick();
  //       },
  //         err => {
  //           this.toastr.error("Pokušajte ponovo", "Došlo je do greške");
  //         });
  //       break;
  //     }
  //     case 'dokumentacija': {

  //       break;
  //     }
  //     default: {
  //       break;
  //     }
  //   }
  // }

  onSubmitEmployees() {
    console.log(1);
    // this.serviceEmp.postUser(this.employeeForm.value, this.documentFile).subscribe(res => {
    //   this.clearMessageForm();
    //   this.toastr.success("Uspješno");
    //   this.resetForm();
    //   this.service.refreshMessageList();
    //   this.closeClick();
    // },
    //   err => {
    //     this.toastr.error("Pokušajte ponovo", "Došlo je do greške");
    //   });
  }


}
