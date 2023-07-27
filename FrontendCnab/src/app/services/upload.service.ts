import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ApiService } from "./api.service";

@Injectable({
  providedIn: "root",
})
export class UploadService {
  constructor(private api: ApiService) {}

  async uploadFile(file: File) {
    const formData = new FormData();
    
    formData.append("arquivos", file)

    return this.api.postUpload<any>("/arquivo/upload", formData);
  }

  async carregarArquivos() {
    return this.api.get<any>("/arquivo");
  }
}
