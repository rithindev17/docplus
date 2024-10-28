import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { ScanServiceBase } from "./base/scan.service.base";

@Injectable()
export class ScanService extends ScanServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
