import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { DiseaseModuleBase } from "./base/disease.module.base";
import { DiseaseService } from "./disease.service";
import { DiseaseController } from "./disease.controller";
import { DiseaseResolver } from "./disease.resolver";

@Module({
  imports: [DiseaseModuleBase, forwardRef(() => AuthModule)],
  controllers: [DiseaseController],
  providers: [DiseaseService, DiseaseResolver],
  exports: [DiseaseService],
})
export class DiseaseModule {}
