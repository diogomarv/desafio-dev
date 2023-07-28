import { Component } from "@angular/core";
import { UploadService } from "../services/upload.service";
import { IArquivo } from "../models/interfaces/IArquivos";

@Component({
  selector: "app-upload",
  templateUrl: "./upload.component.html",
  styleUrls: ["./upload.component.scss"],
})
export class UploadComponent {
  uploadStatus: string = "select";
  selectedFile: File | null = null;
  filename: string = "";
  arquivos!: IArquivo[];
  loading: boolean = false;

  constructor(private uploadService: UploadService) {}

  async ngOnInit(): Promise<void> {
    this.carregarArquivos();
  }

  async onFileSelected(event: Event): Promise<void> {
    const inputElement = event.target as HTMLInputElement;

    if (inputElement.files && inputElement.files.length > 0) {
      try {
        this.selectedFile = inputElement.files[0];
        this.filename = this.selectedFile.name;

        await this.uploadFile();
        this.uploadStatus = "done";

        this.carregarArquivos();
      } catch (error) {
        console.log("Error ==> ", error);
        this.uploadStatus = "error";
      }
    } else {
      this.uploadStatus = "select";
    }
  }

  async carregarArquivos() {
    try {
      this.loading = true;
      this.arquivos = await this.uploadService.carregarArquivos();
    } catch (error) {
    } finally {
      this.loading = false;
    }
  }

  async uploadFile(): Promise<void> {
    if (this.selectedFile) {
      this.uploadStatus = "upload";

      await this.uploadService.uploadFile(this.selectedFile);
    }
  }
}
