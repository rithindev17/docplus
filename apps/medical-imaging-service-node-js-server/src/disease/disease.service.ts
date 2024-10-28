import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { DiseaseServiceBase } from "./base/disease.service.base";

@Injectable()
export class DiseaseService extends DiseaseServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
