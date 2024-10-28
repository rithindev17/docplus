import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { ScanModuleBase } from "./base/scan.module.base";
import { ScanService } from "./scan.service";
import { ScanController } from "./scan.controller";
import { ScanResolver } from "./scan.resolver";

@Module({
  imports: [ScanModuleBase, forwardRef(() => AuthModule)],
  controllers: [ScanController],
  providers: [ScanService, ScanResolver],
  exports: [ScanService],
})
export class ScanModule {}
